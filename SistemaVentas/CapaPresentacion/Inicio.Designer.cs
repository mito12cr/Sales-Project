
namespace CapaPresentacion
{
    partial class Inicio
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
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.MnuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.MnuMantenimientos = new FontAwesome.Sharp.IconMenuItem();
            this.MnuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.MnuCategorias = new FontAwesome.Sharp.IconMenuItem();
            this.MenuOTros = new FontAwesome.Sharp.IconMenuItem();
            this.MnuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.MnuRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.MnuVerDetalles = new FontAwesome.Sharp.IconMenuItem();
            this.MnuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.MnuRVenta = new FontAwesome.Sharp.IconMenuItem();
            this.MnuVerDetalle = new FontAwesome.Sharp.IconMenuItem();
            this.MnuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.MnuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.MnuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.MnuAyuda = new FontAwesome.Sharp.IconMenuItem();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.lblusuario = new System.Windows.Forms.Label();
            this.lblusuario2 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 195);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1782, 860);
            this.Contenedor.TabIndex = 8;
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuUsuarios,
            this.MnuMantenimientos,
            this.MnuCompras,
            this.MnuVentas,
            this.MnuProveedores,
            this.MnuClientes,
            this.MnuReportes,
            this.MnuAyuda});
            this.menuMain.Location = new System.Drawing.Point(0, 107);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1782, 88);
            this.menuMain.TabIndex = 5;
            this.menuMain.Text = "menuStrip2";
            // 
            // MnuUsuarios
            // 
            this.MnuUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserNinja;
            this.MnuUsuarios.IconColor = System.Drawing.Color.Black;
            this.MnuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuUsuarios.IconSize = 60;
            this.MnuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuUsuarios.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuUsuarios.Name = "MnuUsuarios";
            this.MnuUsuarios.Size = new System.Drawing.Size(74, 84);
            this.MnuUsuarios.Text = "Usuario";
            this.MnuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MnuUsuarios.Click += new System.EventHandler(this.MnuUsuarios_Click);
            // 
            // MnuMantenimientos
            // 
            this.MnuMantenimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuProductos,
            this.MnuCategorias,
            this.MenuOTros});
            this.MnuMantenimientos.IconChar = FontAwesome.Sharp.IconChar.Briefcase;
            this.MnuMantenimientos.IconColor = System.Drawing.Color.Black;
            this.MnuMantenimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuMantenimientos.IconSize = 60;
            this.MnuMantenimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuMantenimientos.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuMantenimientos.Name = "MnuMantenimientos";
            this.MnuMantenimientos.Size = new System.Drawing.Size(130, 84);
            this.MnuMantenimientos.Text = "Mantenimientos";
            this.MnuMantenimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MnuProductos
            // 
            this.MnuProductos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuProductos.IconColor = System.Drawing.Color.Black;
            this.MnuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuProductos.Name = "MnuProductos";
            this.MnuProductos.Size = new System.Drawing.Size(163, 26);
            this.MnuProductos.Text = "Productos";
            this.MnuProductos.Click += new System.EventHandler(this.MnuProductos_Click);
            // 
            // MnuCategorias
            // 
            this.MnuCategorias.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuCategorias.IconColor = System.Drawing.Color.Black;
            this.MnuCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuCategorias.Name = "MnuCategorias";
            this.MnuCategorias.Size = new System.Drawing.Size(163, 26);
            this.MnuCategorias.Text = "Categorias";
            this.MnuCategorias.Click += new System.EventHandler(this.MnuCategorias_Click);
            // 
            // MenuOTros
            // 
            this.MenuOTros.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MenuOTros.IconColor = System.Drawing.Color.Black;
            this.MenuOTros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuOTros.Name = "MenuOTros";
            this.MenuOTros.Size = new System.Drawing.Size(163, 26);
            this.MenuOTros.Text = "Otros";
            // 
            // MnuCompras
            // 
            this.MnuCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuRegistrarCompra,
            this.MnuVerDetalles});
            this.MnuCompras.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.MnuCompras.IconColor = System.Drawing.Color.Black;
            this.MnuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuCompras.IconSize = 60;
            this.MnuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuCompras.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuCompras.Name = "MnuCompras";
            this.MnuCompras.Size = new System.Drawing.Size(82, 84);
            this.MnuCompras.Text = "Compras";
            this.MnuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MnuRegistrarCompra
            // 
            this.MnuRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.MnuRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuRegistrarCompra.Name = "MnuRegistrarCompra";
            this.MnuRegistrarCompra.Size = new System.Drawing.Size(208, 26);
            this.MnuRegistrarCompra.Text = "Registrar Compra";
            this.MnuRegistrarCompra.Click += new System.EventHandler(this.MnuRegistrarCompra_Click);
            // 
            // MnuVerDetalles
            // 
            this.MnuVerDetalles.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuVerDetalles.IconColor = System.Drawing.Color.Black;
            this.MnuVerDetalles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuVerDetalles.Name = "MnuVerDetalles";
            this.MnuVerDetalles.Size = new System.Drawing.Size(208, 26);
            this.MnuVerDetalles.Text = "Ver Detalles";
            // 
            // MnuVentas
            // 
            this.MnuVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuRVenta,
            this.MnuVerDetalle});
            this.MnuVentas.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.MnuVentas.IconColor = System.Drawing.Color.Black;
            this.MnuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuVentas.IconSize = 60;
            this.MnuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuVentas.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuVentas.Name = "MnuVentas";
            this.MnuVentas.Size = new System.Drawing.Size(74, 84);
            this.MnuVentas.Text = "Ventas";
            this.MnuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MnuRVenta
            // 
            this.MnuRVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuRVenta.IconColor = System.Drawing.Color.Black;
            this.MnuRVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuRVenta.Name = "MnuRVenta";
            this.MnuRVenta.Size = new System.Drawing.Size(192, 26);
            this.MnuRVenta.Text = "Registrar Venta";
            this.MnuRVenta.Click += new System.EventHandler(this.MnuRVenta_Click);
            // 
            // MnuVerDetalle
            // 
            this.MnuVerDetalle.IconChar = FontAwesome.Sharp.IconChar.None;
            this.MnuVerDetalle.IconColor = System.Drawing.Color.Black;
            this.MnuVerDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuVerDetalle.Name = "MnuVerDetalle";
            this.MnuVerDetalle.Size = new System.Drawing.Size(192, 26);
            this.MnuVerDetalle.Text = "Ver Detalle";
            // 
            // MnuProveedores
            // 
            this.MnuProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuProveedores.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.MnuProveedores.IconColor = System.Drawing.Color.Black;
            this.MnuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuProveedores.IconSize = 60;
            this.MnuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuProveedores.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuProveedores.Name = "MnuProveedores";
            this.MnuProveedores.Size = new System.Drawing.Size(105, 84);
            this.MnuProveedores.Text = "Proveedores";
            this.MnuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MnuProveedores.Click += new System.EventHandler(this.MnuProveedores_Click);
            // 
            // MnuClientes
            // 
            this.MnuClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.MnuClientes.IconColor = System.Drawing.Color.Black;
            this.MnuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuClientes.IconSize = 60;
            this.MnuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuClientes.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuClientes.Name = "MnuClientes";
            this.MnuClientes.Size = new System.Drawing.Size(75, 84);
            this.MnuClientes.Text = "Clientes";
            this.MnuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MnuClientes.Click += new System.EventHandler(this.MnuClientes_Click);
            // 
            // MnuReportes
            // 
            this.MnuReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.MnuReportes.IconColor = System.Drawing.Color.Black;
            this.MnuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuReportes.IconSize = 60;
            this.MnuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuReportes.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuReportes.Name = "MnuReportes";
            this.MnuReportes.Size = new System.Drawing.Size(82, 84);
            this.MnuReportes.Text = "Reportes";
            this.MnuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MnuAyuda
            // 
            this.MnuAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MnuAyuda.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.MnuAyuda.IconColor = System.Drawing.Color.Black;
            this.MnuAyuda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MnuAyuda.IconSize = 60;
            this.MnuAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuAyuda.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MnuAyuda.Name = "MnuAyuda";
            this.MnuAyuda.Size = new System.Drawing.Size(74, 84);
            this.MnuAyuda.Text = "Ayuda";
            this.MnuAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(470, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(469, 48);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Sistema de Punto Venta";
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1782, 107);
            this.menuTitulo.TabIndex = 6;
            this.menuTitulo.Text = "menuStrip3";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(1056, 41);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(110, 29);
            this.lblusuario.TabIndex = 9;
            this.lblusuario.Text = "Usuario:";
            // 
            // lblusuario2
            // 
            this.lblusuario2.AutoSize = true;
            this.lblusuario2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblusuario2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario2.Location = new System.Drawing.Point(1199, 41);
            this.lblusuario2.Name = "lblusuario2";
            this.lblusuario2.Size = new System.Drawing.Size(124, 29);
            this.lblusuario2.TabIndex = 10;
            this.lblusuario2.Text = "Usuario...";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1055);
            this.Controls.Add(this.lblusuario2);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuTitulo);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio2";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.MenuStrip menuMain;
        private FontAwesome.Sharp.IconMenuItem MnuUsuarios;
        private FontAwesome.Sharp.IconMenuItem MnuMantenimientos;
        private FontAwesome.Sharp.IconMenuItem MnuCompras;
        private FontAwesome.Sharp.IconMenuItem MnuVentas;
        private FontAwesome.Sharp.IconMenuItem MnuProveedores;
        private FontAwesome.Sharp.IconMenuItem MnuClientes;
        private FontAwesome.Sharp.IconMenuItem MnuReportes;
        private FontAwesome.Sharp.IconMenuItem MnuAyuda;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label lblusuario2;
        private FontAwesome.Sharp.IconMenuItem MnuProductos;
        private FontAwesome.Sharp.IconMenuItem MnuCategorias;
        private FontAwesome.Sharp.IconMenuItem MenuOTros;
        private FontAwesome.Sharp.IconMenuItem MnuRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem MnuVerDetalles;
        private FontAwesome.Sharp.IconMenuItem MnuRVenta;
        private FontAwesome.Sharp.IconMenuItem MnuVerDetalle;
    }
}