namespace GenisysATMCRUD
{
    partial class FrmServicioCliente
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblServicioC = new System.Windows.Forms.Label();
            this.lstServiciosC = new System.Windows.Forms.ListBox();
            this.lblServiciosP = new System.Windows.Forms.Label();
            this.lstServiciosP = new System.Windows.Forms.ListBox();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.lblsaldo = new System.Windows.Forms.Label();
            this.txtsaldo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblServicioC);
            this.gbDatos.Controls.Add(this.lstServiciosC);
            this.gbDatos.Controls.Add(this.lblServiciosP);
            this.gbDatos.Controls.Add(this.lstServiciosP);
            this.gbDatos.Controls.Add(this.lblClientes);
            this.gbDatos.Controls.Add(this.lstClientes);
            this.gbDatos.Location = new System.Drawing.Point(40, 38);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(714, 314);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // lblServicioC
            // 
            this.lblServicioC.AutoSize = true;
            this.lblServicioC.Location = new System.Drawing.Point(504, 33);
            this.lblServicioC.Name = "lblServicioC";
            this.lblServicioC.Size = new System.Drawing.Size(132, 17);
            this.lblServicioC.TabIndex = 7;
            this.lblServicioC.Text = "Servicios de Cliente";
            // 
            // lstServiciosC
            // 
            this.lstServiciosC.FormattingEnabled = true;
            this.lstServiciosC.ItemHeight = 16;
            this.lstServiciosC.Location = new System.Drawing.Point(507, 70);
            this.lstServiciosC.Name = "lstServiciosC";
            this.lstServiciosC.ScrollAlwaysVisible = true;
            this.lstServiciosC.Size = new System.Drawing.Size(165, 212);
            this.lstServiciosC.TabIndex = 6;
            this.lstServiciosC.Click += new System.EventHandler(this.lstServiciosC_Click);
            // 
            // lblServiciosP
            // 
            this.lblServiciosP.AutoSize = true;
            this.lblServiciosP.Location = new System.Drawing.Point(266, 33);
            this.lblServiciosP.Name = "lblServiciosP";
            this.lblServiciosP.Size = new System.Drawing.Size(65, 17);
            this.lblServiciosP.TabIndex = 5;
            this.lblServiciosP.Text = "Servicios";
            // 
            // lstServiciosP
            // 
            this.lstServiciosP.FormattingEnabled = true;
            this.lstServiciosP.ItemHeight = 16;
            this.lstServiciosP.Location = new System.Drawing.Point(269, 70);
            this.lstServiciosP.Name = "lstServiciosP";
            this.lstServiciosP.ScrollAlwaysVisible = true;
            this.lstServiciosP.Size = new System.Drawing.Size(165, 212);
            this.lstServiciosP.TabIndex = 4;
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new System.Drawing.Point(31, 38);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(58, 17);
            this.lblClientes.TabIndex = 3;
            this.lblClientes.Text = "Clientes";
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 16;
            this.lstClientes.Location = new System.Drawing.Point(34, 75);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.ScrollAlwaysVisible = true;
            this.lstClientes.Size = new System.Drawing.Size(165, 212);
            this.lstClientes.TabIndex = 2;
            this.lstClientes.Click += new System.EventHandler(this.lstClientes_Click);
            // 
            // lblsaldo
            // 
            this.lblsaldo.AutoSize = true;
            this.lblsaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsaldo.Location = new System.Drawing.Point(54, 389);
            this.lblsaldo.Name = "lblsaldo";
            this.lblsaldo.Size = new System.Drawing.Size(51, 20);
            this.lblsaldo.TabIndex = 1;
            this.lblsaldo.Text = "Saldo";
            // 
            // txtsaldo
            // 
            this.txtsaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsaldo.Location = new System.Drawing.Point(139, 389);
            this.txtsaldo.Name = "txtsaldo";
            this.txtsaldo.Size = new System.Drawing.Size(212, 26);
            this.txtsaldo.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(93, 450);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 36);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(259, 450);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 36);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(422, 450);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 36);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(595, 450);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(130, 36);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmServicioCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 498);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtsaldo);
            this.Controls.Add(this.lblsaldo);
            this.Controls.Add(this.gbDatos);
            this.Name = "FrmServicioCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicio Cliente";
            this.Load += new System.EventHandler(this.FrmServicioCliente_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblServicioC;
        private System.Windows.Forms.ListBox lstServiciosC;
        private System.Windows.Forms.Label lblServiciosP;
        private System.Windows.Forms.ListBox lstServiciosP;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Label lblsaldo;
        private System.Windows.Forms.TextBox txtsaldo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
    }
}