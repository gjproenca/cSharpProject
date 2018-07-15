namespace frontend
{
    partial class FormAutoresLivros
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
            this.dataGridViewAutoresLivros = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLivro = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.limparCamposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoresLivros)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAutoresLivros
            // 
            this.dataGridViewAutoresLivros.AllowUserToAddRows = false;
            this.dataGridViewAutoresLivros.AllowUserToDeleteRows = false;
            this.dataGridViewAutoresLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutoresLivros.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewAutoresLivros.MultiSelect = false;
            this.dataGridViewAutoresLivros.Name = "dataGridViewAutoresLivros";
            this.dataGridViewAutoresLivros.ReadOnly = true;
            this.dataGridViewAutoresLivros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAutoresLivros.Size = new System.Drawing.Size(713, 150);
            this.dataGridViewAutoresLivros.TabIndex = 0;
            this.dataGridViewAutoresLivros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAutoresLivros_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Autor";
            // 
            // comboBoxAutor
            // 
            this.comboBoxAutor.FormattingEnabled = true;
            this.comboBoxAutor.Location = new System.Drawing.Point(50, 169);
            this.comboBoxAutor.Name = "comboBoxAutor";
            this.comboBoxAutor.Size = new System.Drawing.Size(451, 21);
            this.comboBoxAutor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Livro";
            // 
            // comboBoxLivro
            // 
            this.comboBoxLivro.FormattingEnabled = true;
            this.comboBoxLivro.Location = new System.Drawing.Point(50, 196);
            this.comboBoxLivro.Name = "comboBoxLivro";
            this.comboBoxLivro.Size = new System.Drawing.Size(451, 21);
            this.comboBoxLivro.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.inserirToolStripMenuItem,
            this.alterarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.limparCamposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 537);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // inserirToolStripMenuItem
            // 
            this.inserirToolStripMenuItem.Name = "inserirToolStripMenuItem";
            this.inserirToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.inserirToolStripMenuItem.Text = "Inserir";
            this.inserirToolStripMenuItem.Click += new System.EventHandler(this.inserirToolStripMenuItem_Click);
            // 
            // alterarToolStripMenuItem
            // 
            this.alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
            this.alterarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.alterarToolStripMenuItem.Text = "Alterar";
            this.alterarToolStripMenuItem.Click += new System.EventHandler(this.alterarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem2.Text = "|";
            // 
            // limparCamposToolStripMenuItem
            // 
            this.limparCamposToolStripMenuItem.Name = "limparCamposToolStripMenuItem";
            this.limparCamposToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.limparCamposToolStripMenuItem.Text = "Limpar campos";
            this.limparCamposToolStripMenuItem.Click += new System.EventHandler(this.limparCamposToolStripMenuItem_Click);
            // 
            // FormAutoresLivros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxLivro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAutor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAutoresLivros);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutoresLivros";
            this.Text = "AutoresLivros";
            this.Load += new System.EventHandler(this.AutoresLivros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoresLivros)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAutoresLivros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLivro;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inserirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem limparCamposToolStripMenuItem;
    }
}