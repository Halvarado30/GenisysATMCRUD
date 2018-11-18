namespace GenisysATMCRUD
{
    partial class PantallaPrincipal
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
            this.btnCliente = new System.Windows.Forms.Button();
            this.gbATM = new System.Windows.Forms.GroupBox();
            this.btnServicioClient = new System.Windows.Forms.Button();
            this.btnServicioPublico = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnTarjetaCredito = new System.Windows.Forms.Button();
            this.btnCuentaCliente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbATM.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(45, 72);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(132, 46);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // gbATM
            // 
            this.gbATM.Controls.Add(this.btnCuentaCliente);
            this.gbATM.Controls.Add(this.btnTarjetaCredito);
            this.gbATM.Controls.Add(this.btnConfiguracion);
            this.gbATM.Controls.Add(this.btnServicioPublico);
            this.gbATM.Controls.Add(this.btnServicioClient);
            this.gbATM.Controls.Add(this.btnCliente);
            this.gbATM.Location = new System.Drawing.Point(24, 31);
            this.gbATM.Name = "gbATM";
            this.gbATM.Size = new System.Drawing.Size(547, 249);
            this.gbATM.TabIndex = 1;
            this.gbATM.TabStop = false;
            this.gbATM.Text = "Cajero Automático";
            // 
            // btnServicioClient
            // 
            this.btnServicioClient.Location = new System.Drawing.Point(377, 72);
            this.btnServicioClient.Name = "btnServicioClient";
            this.btnServicioClient.Size = new System.Drawing.Size(132, 46);
            this.btnServicioClient.TabIndex = 1;
            this.btnServicioClient.Text = "Servicio Cliente";
            this.btnServicioClient.UseVisualStyleBackColor = true;
            // 
            // btnServicioPublico
            // 
            this.btnServicioPublico.Location = new System.Drawing.Point(212, 72);
            this.btnServicioPublico.Name = "btnServicioPublico";
            this.btnServicioPublico.Size = new System.Drawing.Size(132, 46);
            this.btnServicioPublico.TabIndex = 2;
            this.btnServicioPublico.Text = "Servicio Publico";
            this.btnServicioPublico.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(377, 173);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(132, 46);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // btnTarjetaCredito
            // 
            this.btnTarjetaCredito.Location = new System.Drawing.Point(212, 173);
            this.btnTarjetaCredito.Name = "btnTarjetaCredito";
            this.btnTarjetaCredito.Size = new System.Drawing.Size(132, 46);
            this.btnTarjetaCredito.TabIndex = 4;
            this.btnTarjetaCredito.Text = "Tarjeta Crédito";
            this.btnTarjetaCredito.UseVisualStyleBackColor = true;
            // 
            // btnCuentaCliente
            // 
            this.btnCuentaCliente.Location = new System.Drawing.Point(45, 173);
            this.btnCuentaCliente.Name = "btnCuentaCliente";
            this.btnCuentaCliente.Size = new System.Drawing.Size(132, 46);
            this.btnCuentaCliente.TabIndex = 5;
            this.btnCuentaCliente.Text = "Cuenta Cliente";
            this.btnCuentaCliente.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(401, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 46);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 354);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbATM);
            this.Name = "PantallaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.gbATM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.GroupBox gbATM;
        private System.Windows.Forms.Button btnCuentaCliente;
        private System.Windows.Forms.Button btnTarjetaCredito;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnServicioPublico;
        private System.Windows.Forms.Button btnServicioClient;
        private System.Windows.Forms.Button btnSalir;
    }
}