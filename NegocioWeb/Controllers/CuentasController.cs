using BaseDeDatos.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace NegocioWeb.Controllers
{
    public class CuentasController : Controller
    {
        private readonly NegocioWebContext _context;
        public CuentasController(NegocioWebContext context)
        {
            _context = context;
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Moldes.Usuarios.Usuario usuario)
        {
            string conexion = "Data Source=LAPTOP-OIQBSE4M\\SQLEXPRESS; Initial Catalog=NegocioWeb; User=Luis; Password=1234;TrustServerCertificate=True";
            string procealma = "sp_CrearUsuario";
            string resultado = "";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                using (SqlCommand sp = new SqlCommand(procealma,conn))
                {
                    sp.CommandType = System.Data.CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("@Nombre",usuario.Nombre);
                    sp.Parameters.AddWithValue("@Correo", usuario.Correo);
                    sp.Parameters.AddWithValue("@Contra", usuario.Contraseña);
                    sp.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    sp.Parameters.AddWithValue("@Rol", "Usuario");

                    conn.Open();

                    //sp.ExecuteNonQuery();
                    SqlDataReader leer = sp.ExecuteReader();
                    while (leer.Read())
                    {
                        
                        resultado = leer["resultado"].ToString();
                    }

                    conn.Close();

                }
            }

            //var spcuenta = _context.sp_cuenta(usuario.Nombre, usuario.Correo, usuario.Contraseña, DateTime.Now, "Usuario");
            if (resultado== "Este correo ya existe")
            {
                return View();
            }
            else if (resultado == "Creación del usuario exitosa")
            {
                var usuarionuevo = (from d in _context.Usuarios
                                    where d.Correo == usuario.Correo
                                    select new Moldes.Usuarios.Usuario
                                    {
                                        Correo = usuario.Correo,
                                        Contraseña = usuario.Contraseña,
                                        Nombre = usuario.Nombre,

                                    });
                return RedirectToAction("IndexAdmin", "VentanaInicio",usuarionuevo);
            }
            else
            {
                return View();
            }
            
        }
    }
}
