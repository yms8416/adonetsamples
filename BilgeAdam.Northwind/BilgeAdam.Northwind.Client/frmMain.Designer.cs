namespace BilgeAdam.Northwind.Client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.uygulamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.msbAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.çalışanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.msbNewEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uygulamaToolStripMenuItem,
            this.ürünYönetimiToolStripMenuItem,
            this.çalışanlarToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(755, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // uygulamaToolStripMenuItem
            // 
            this.uygulamaToolStripMenuItem.Name = "uygulamaToolStripMenuItem";
            this.uygulamaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.uygulamaToolStripMenuItem.Text = "Uygulama";
            // 
            // ürünYönetimiToolStripMenuItem
            // 
            this.ürünYönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbProducts,
            this.msbAddProduct});
            this.ürünYönetimiToolStripMenuItem.Name = "ürünYönetimiToolStripMenuItem";
            this.ürünYönetimiToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.ürünYönetimiToolStripMenuItem.Text = "Ürün Yönetimi";
            // 
            // msbProducts
            // 
            this.msbProducts.Name = "msbProducts";
            this.msbProducts.Size = new System.Drawing.Size(135, 22);
            this.msbProducts.Text = "Ürün Listesi";
            this.msbProducts.Click += new System.EventHandler(this.msbProducts_Click);
            // 
            // msbAddProduct
            // 
            this.msbAddProduct.Name = "msbAddProduct";
            this.msbAddProduct.Size = new System.Drawing.Size(135, 22);
            this.msbAddProduct.Text = "Ürün Ekle";
            this.msbAddProduct.Click += new System.EventHandler(this.msbAddProduct_Click);
            // 
            // çalışanlarToolStripMenuItem
            // 
            this.çalışanlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbEmployees,
            this.msbNewEmployee});
            this.çalışanlarToolStripMenuItem.Name = "çalışanlarToolStripMenuItem";
            this.çalışanlarToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.çalışanlarToolStripMenuItem.Text = "İnsan Kaynakları";
            // 
            // msbEmployees
            // 
            this.msbEmployees.Name = "msbEmployees";
            this.msbEmployees.Size = new System.Drawing.Size(152, 22);
            this.msbEmployees.Text = "Çalışanlar";
            this.msbEmployees.Click += new System.EventHandler(this.msbEmployees_Click);
            // 
            // msbNewEmployee
            // 
            this.msbNewEmployee.Name = "msbNewEmployee";
            this.msbNewEmployee.Size = new System.Drawing.Size(152, 22);
            this.msbNewEmployee.Text = "Yeni Çalışan";
            this.msbNewEmployee.Click += new System.EventHandler(this.msbNewEmployee_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 397);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Text = "Northwind Satış & Pazarlama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem uygulamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünYönetimiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbProducts;
        private System.Windows.Forms.ToolStripMenuItem çalışanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbEmployees;
        private System.Windows.Forms.ToolStripMenuItem msbAddProduct;
        private System.Windows.Forms.ToolStripMenuItem msbNewEmployee;
    }
}

