using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BilgeAdam.Northwind.Client.Controls
{
    public class EnumComboBox : ComboBox
    {
        public EnumComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += EnumComboBox_SelectedIndexChanged;
        }
        private void EnumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var convertedValue = SelectedValue as EnumData;
            if (convertedValue != null)
            {
                return;
            }
            if (EnumType != null && !string.IsNullOrEmpty(SelectedValue.ToString()))
            {
                SelectedEnumValue = Convert.ToInt32(Enum.Parse(EnumType, SelectedValue.ToString()));
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (EnumType == null)
            {
                return;
            }
            var list = Enum.GetNames(EnumType);
            var ds = new List<EnumData>();
            foreach (var item in list)
            {
                ds.Add(new EnumData(GetEnumText(item), item));
            }

            DataSource = ds;
            DisplayMember = "Text";//Bkz. :61
            ValueMember = "EnumValue"; //Bkz :62
        }
        public Type EnumType { get; set; }
        public int SelectedEnumValue { get; set; }
        private string GetEnumText(string value)
        {
            var type = EnumType;
            var member = type.GetMember(value.ToString())[0];
            var attribute = member.CustomAttributes.ToArray()[0];
            return attribute.NamedArguments[0].TypedValue.Value.ToString();
        }
        class EnumData
        {
            public EnumData(string text, string value)
            {
                Text = text;
                EnumValue = value;
            }
            public string Text { get; set; }
            public string EnumValue { get; set; }
        }

    }
}
