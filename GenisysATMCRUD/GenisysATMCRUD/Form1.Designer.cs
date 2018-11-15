namespace GenisysATMCRUD
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblapellido = new System.Windows.Forms.Label();
            this.lblidentidad = new System.Windows.Forms.Label();
            this.lbldireccion = new System.Windows.Forms.Label();
            this.lbltelefono = new System.Windows.Forms.Label();
            this.lblcelular = new System.Windows.Forms.Label();
            this.txtnombres = new System.Windows.Forms.TextBox();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.txtidentidad = new System.Windows.Forms.TextBox();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtcelular = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(65, 63);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(69, 17);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Nombres:";
            // 
            // lblapellido
            // 
            this.lblapellido.AutoSize = true;
            this.lblapellido.Location = new System.Drawing.Point(65, 103);
            this.lblapellido.Name = "lblapellido";
            this.lblapellido.Size = new System.Drawing.Size(69, 17);
            this.lblapellido.TabIndex = 1;
            this.lblapellido.Text = "Apellidos:";
            // 
            // lblidentidad
            // 
            this.lblidentidad.AutoSize = true;
            this.lblidentidad.Location = new System.Drawing.Point(65, 144);
            this.lblidentidad.Name = "lblidentidad";
            this.lblidentidad.Size = new System.Drawing.Size(70, 17);
            this.lblidentidad.TabIndex = 2;
            this.lblidentidad.Text = "Identidad:";
            // 
            // lbldireccion
            // 
            this.lbldireccion.AutoSize = true;
            this.lbldireccion.Location = new System.Drawing.Point(65, 183);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(71, 17);
            this.lbldireccion.TabIndex = 3;
            this.lbldireccion.Text = "Dirección:";
            // 
            // lbltelefono
            // 
            this.lbltelefono.AutoSize = true;
            this.lbltelefono.Location = new System.Drawing.Point(65, 216);
            this.lbltelefono.Name = "lbltelefono";
            this.lbltelefono.Size = new System.Drawing.Size(68, 17);
            this.lbltelefono.TabIndex = 4;
            this.lbltelefono.Text = "Teléfono:";
            // 
            // lblcelular
            // 
            this.lblcelular.AutoSize = true;
            this.lblcelular.Location = new System.Drawing.Point(65, 256);
            this.lblcelular.Name = "lblcelular";
            this.lblcelular.Size = new System.Drawing.Size(56, 17);
            this.lblcelular.TabIndex = 5;
            this.lblcelular.Text = "Celular:";
            // 
            // txtnombres
            // 
            this.txtnombres.Location = new System.Drawing.Point(140, 63);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(289, 22);
            this.txtnombres.TabIndex = 6;
            // 
            // txtapellidos
            // 
            this.txtapellidos.Location = new System.Drawing.Point(140, 103);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(289, 22);
            this.txtapellidos.TabIndex = 7;
            // 
            // txtidentidad
            // 
            this.txtidentidad.Location = new System.Drawing.Point(140, 144);
            this.txtidentidad.Name = "txtidentidad";
            this.txtidentidad.Size = new System.Drawing.Size(289, 22);
            this.txtidentidad.TabIndex = 8;
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(140, 183);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(289, 22);
            this.txtdireccion.TabIndex = 9;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(140, 216);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(289, 22);
            this.txttelefono.TabIndex = 10;
            // 
            // txtcelular
            // 
            this.txtcelular.Location = new System.Drawing.Point(140, 256);
            this.txtcelular.Name = "txtcelular";
            this.txtcelular.Size = new System.Drawing.Size(289, 22);
            this.txtcelular.TabIndex = 11;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(68, 322);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(129, 36);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 434);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtcelular);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.txtidentidad);
            this.Controls.Add(this.txtapellidos);
            this.Controls.Add(this.txtnombres);
            this.Controls.Add(this.lblcelular);
            this.Controls.Add(this.lbltelefono);
            this.Controls.Add(this.lbldireccion);
            this.Controls.Add(this.lblidentidad);
            this.Controls.Add(this.lblapellido);
            this.Controls.Add(this.lblnombre);
            this.Name = "Form1";
            this.Text = "Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblapellido;
        private System.Windows.Forms.Label lblidentidad;
        private System.Windows.Forms.Label lbldireccion;
        private System.Windows.Forms.Label lbltelefono;
        private System.Windows.Forms.Label lblcelular;
        private System.Windows.Forms.TextBox txtnombres;
        private System.Windows.Forms.TextBox txtapellidos;
        private System.Windows.Forms.TextBox txtidentidad;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtcelular;
        private System.Windows.Forms.Button btnAgregar;
    }
}

