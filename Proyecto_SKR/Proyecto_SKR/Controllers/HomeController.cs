using Proyecto_SKR.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SKR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //[Almacenar la consulta SELECT en la List]
            List<Requerimiento> modelo = new List<Requerimiento>();

            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [Formulario] ORDER BY id_req DESC;", con);            
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    modelo.Add(new Requerimiento
                    {
                        id_req = dr.GetInt32(0),
                        gerente_comercial = dr.GetString(1),
                        motivo_req = dr.GetString(2),
                        cliente_nom = dr.GetString(3),
                        gerencia = dr.GetString(4),
                        empresa_cliente = dr.GetString(5),
                        email_cliente = dr.GetString(6),
                        telefono_cliente = dr.GetString(7),
                        perfil_solicitante = dr.GetString(8),
                        carrera_solicitante = dr.GetString(9),
                        nivel_estudios = dr.GetString(10),
                        tiempo_experiencia = dr.GetString(11),
                        catidad_recursos = dr.GetInt32(12),
                        areas_carreras = dr.GetString(13),
                        certificaciones = dr.GetString(14),
                        prioridad_requerimiento = dr.GetString(15),
                        fecha_sol_req = dr.GetDateTime(16),
                        fecha_env_sol = dr.GetDateTime(17),
                        fecha_cierre_req = dr.GetDateTime(18),
                        rango_edad = dr.GetString(19),
                        genero = dr.GetString(20),
                        idiomas = dr.GetString(21),
                        rango_tarifa = dr.GetString(22),
                        rango_sueldo = dr.GetString(23),
                        adicionales = dr.GetString(24),
                        compu_trabajo = dr.GetString(25),
                        compu_trabajo_fecha = dr.GetDateTime(26),
                        redes_sociales = dr.GetString(27),
                        redes_sociales_fecha = dr.GetDateTime(28),
                        pagina_web = dr.GetString(29),
                        pagina_web_fecha = dr.GetDateTime(30),
                        occ_mundial = dr.GetString(31),
                        occ_mundial_fecha = dr.GetDateTime(32)
                    });
                }
                return View(modelo);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        } 
        public ActionResult Formulario()
        {
            //[Donde se encuentra el formulario de Insert]
            return View();
        }
        public ActionResult GuardarRegistro(String gerente_comercial, String motivo_req, String cliente_nom, String gerencia, String empresa_cliente,
            String email_cliente, String telefono_cliente, String perfil_solicitante, String carrera_solicitante, String nivel_estudios,
            String tiempo_experiencia, int catidad_recursos, String areas_carreras, String certificaciones, String prioridad_requerimiento,
            DateTime fecha_sol_req, DateTime fecha_env_sol, DateTime fecha_cierre_req, String rango_edad, String genero, String idiomas,
            String rango_tarifa, String rango_sueldo, String adicionales, String compu_trabajo, DateTime compu_trabajo_fecha, String redes_sociales,
            DateTime redes_sociales_fecha, String pagina_web, DateTime pagina_web_fecha, String occ_mundial, DateTime occ_mundial_fecha)
        {
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [Formulario] (gerente_comercial,motivo_req,cliente_nom,gerencia,empresa_cliente,
            email_cliente,telefono_cliente,perfil_solicitante,carrera_solicitante,nivel_estudios,tiempo_experiencia,catidad_recursos,
            areas_carreras,certificaciones,prioridad_requerimiento,fecha_sol_req,fecha_env_sol,fecha_cierre_req,rango_edad,genero,
            idiomas,rango_tarifa,rango_sueldo,adicionales,compu_trabajo,compu_trabajo_fecha,redes_sociales,redes_sociales_fecha,
            pagina_web,pagina_web_fecha,occ_mundial,occ_mundial_fecha) VALUES (@gerente_comercial,@motivo_req,@cliente_nom,@gerencia,@empresa_cliente,
            @email_cliente,@telefono_cliente,@perfil_solicitante,@carrera_solicitante,@nivel_estudios,@tiempo_experiencia,@catidad_recursos,
            @areas_carreras,@certificaciones,@prioridad_requerimiento,@fecha_sol_req,@fecha_env_sol,@fecha_cierre_req,@rango_edad,@genero,
            @idiomas,@rango_tarifa,@rango_sueldo,@adicionales,@compu_trabajo,@compu_trabajo_fecha,@redes_sociales,@redes_sociales_fecha,
            @pagina_web,@pagina_web_fecha,@occ_mundial,@occ_mundial_fecha)", con);
            cmd.Parameters.Add(new SqlParameter("gerente_comercial", gerente_comercial));
            cmd.Parameters.Add(new SqlParameter("motivo_req", motivo_req));
            cmd.Parameters.Add(new SqlParameter("cliente_nom", cliente_nom));
            cmd.Parameters.Add(new SqlParameter("gerencia", gerencia));
            cmd.Parameters.Add(new SqlParameter("empresa_cliente", empresa_cliente));
            cmd.Parameters.Add(new SqlParameter("email_cliente", email_cliente));
            cmd.Parameters.Add(new SqlParameter("telefono_cliente", telefono_cliente));
            cmd.Parameters.Add(new SqlParameter("perfil_solicitante", perfil_solicitante));
            cmd.Parameters.Add(new SqlParameter("carrera_solicitante", carrera_solicitante));
            cmd.Parameters.Add(new SqlParameter("nivel_estudios", nivel_estudios));
            cmd.Parameters.Add(new SqlParameter("tiempo_experiencia", tiempo_experiencia));
            cmd.Parameters.Add(new SqlParameter("catidad_recursos", catidad_recursos));
            cmd.Parameters.Add(new SqlParameter("areas_carreras", areas_carreras));
            cmd.Parameters.Add(new SqlParameter("certificaciones", certificaciones));
            cmd.Parameters.Add(new SqlParameter("prioridad_requerimiento", prioridad_requerimiento));
            cmd.Parameters.Add(new SqlParameter("fecha_sol_req", fecha_sol_req));
            cmd.Parameters.Add(new SqlParameter("fecha_env_sol", fecha_env_sol));
            cmd.Parameters.Add(new SqlParameter("fecha_cierre_req", fecha_cierre_req));
            cmd.Parameters.Add(new SqlParameter("rango_edad", rango_edad));
            cmd.Parameters.Add(new SqlParameter("genero", genero));
            cmd.Parameters.Add(new SqlParameter("idiomas", idiomas));
            cmd.Parameters.Add(new SqlParameter("rango_tarifa", rango_tarifa));
            cmd.Parameters.Add(new SqlParameter("rango_sueldo", rango_sueldo));
            cmd.Parameters.Add(new SqlParameter("adicionales", adicionales));
            cmd.Parameters.Add(new SqlParameter("compu_trabajo", compu_trabajo));
            cmd.Parameters.Add(new SqlParameter("compu_trabajo_fecha", compu_trabajo_fecha));
            cmd.Parameters.Add(new SqlParameter("redes_sociales", redes_sociales));
            cmd.Parameters.Add(new SqlParameter("redes_sociales_fecha", redes_sociales_fecha));
            cmd.Parameters.Add(new SqlParameter("pagina_web", pagina_web));
            cmd.Parameters.Add(new SqlParameter("pagina_web_fecha", pagina_web_fecha));
            cmd.Parameters.Add(new SqlParameter("occ_mundial", occ_mundial));
            cmd.Parameters.Add(new SqlParameter("occ_mundial_fecha", occ_mundial_fecha));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //return Content("Requerimiento Guardado !exito!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult ConsultarRegistroId(Int32 id_req)
        {
            //[Almacenar la consulta SELECT en la List]
            List<Requerimiento> modelo = new List<Requerimiento>();

            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [Formulario]  WHERE id_req=@id_req;", con);
            cmd.Parameters.Add(new SqlParameter("id_req", id_req));
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    modelo.Add(new Requerimiento { id_req = dr.GetInt32(0), gerente_comercial = dr.GetString(1), motivo_req = dr.GetString(2),
                        cliente_nom = dr.GetString(3), gerencia = dr.GetString(4), empresa_cliente = dr.GetString(5), email_cliente = dr.GetString(6),
                        telefono_cliente = dr.GetString(7), perfil_solicitante = dr.GetString(8), carrera_solicitante = dr.GetString(9),
                        nivel_estudios = dr.GetString(10), tiempo_experiencia = dr.GetString(11), catidad_recursos = dr.GetInt32(12),
                        areas_carreras = dr.GetString(13), certificaciones = dr.GetString(14), prioridad_requerimiento = dr.GetString(15),
                        fecha_sol_req = dr.GetDateTime(16),  fecha_env_sol = dr.GetDateTime(17), fecha_cierre_req = dr.GetDateTime(18),
                        rango_edad = dr.GetString(19), genero = dr.GetString(20), idiomas = dr.GetString(21), rango_tarifa = dr.GetString(22),
                        rango_sueldo = dr.GetString(23), adicionales = dr.GetString(24), compu_trabajo= dr.GetString(25),
                        compu_trabajo_fecha = dr.GetDateTime(26), redes_sociales = dr.GetString(27), redes_sociales_fecha = dr.GetDateTime(28),
                        pagina_web = dr.GetString(29), pagina_web_fecha = dr.GetDateTime(30), occ_mundial = dr.GetString(31),
                        occ_mundial_fecha = dr.GetDateTime(32)});
                }
                return View(modelo);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult ConsultarRegistro(String gerente_comercial, String cliente_nom, String empresa_cliente, String perfil_solicitante)
        {
            //[Almacenar la consulta SELECT en la List]
            List<Requerimiento> modelo = new List<Requerimiento>();

            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [Formulario] WHERE gerente_comercial=@gerente_comercial OR
                                            cliente_nom=@cliente_nom OR empresa_cliente=@empresa_cliente OR perfil_solicitante=@perfil_solicitante;", con);
            cmd.Parameters.Add(new SqlParameter("gerente_comercial", gerente_comercial));
            cmd.Parameters.Add(new SqlParameter("cliente_nom", cliente_nom));
            cmd.Parameters.Add(new SqlParameter("empresa_cliente", empresa_cliente));
            cmd.Parameters.Add(new SqlParameter("perfil_solicitante", perfil_solicitante));
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    modelo.Add(new Requerimiento
                    {
                        id_req = dr.GetInt32(0),
                        gerente_comercial = dr.GetString(1),
                        motivo_req = dr.GetString(2),
                        cliente_nom = dr.GetString(3),
                        gerencia = dr.GetString(4),
                        empresa_cliente = dr.GetString(5),
                        email_cliente = dr.GetString(6),
                        telefono_cliente = dr.GetString(7),
                        perfil_solicitante = dr.GetString(8),
                        carrera_solicitante = dr.GetString(9),
                        nivel_estudios = dr.GetString(10),
                        tiempo_experiencia = dr.GetString(11),
                        catidad_recursos = dr.GetInt32(12),
                        areas_carreras = dr.GetString(13),
                        certificaciones = dr.GetString(14),
                        prioridad_requerimiento = dr.GetString(15),
                        fecha_sol_req = dr.GetDateTime(16),
                        fecha_env_sol = dr.GetDateTime(17),
                        fecha_cierre_req = dr.GetDateTime(18),
                        rango_edad = dr.GetString(19),
                        genero = dr.GetString(20),
                        idiomas = dr.GetString(21),
                        rango_tarifa = dr.GetString(22),
                        rango_sueldo = dr.GetString(23),
                        adicionales = dr.GetString(24),
                        compu_trabajo = dr.GetString(25),
                        compu_trabajo_fecha = dr.GetDateTime(26),
                        redes_sociales = dr.GetString(27),
                        redes_sociales_fecha = dr.GetDateTime(28),
                        pagina_web = dr.GetString(29),
                        pagina_web_fecha = dr.GetDateTime(30),
                        occ_mundial = dr.GetString(31),
                        occ_mundial_fecha = dr.GetDateTime(32)
                    });
                }
                return View(modelo);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult BorrarRegistro(Int32 id_req)
        {
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [Formulario] WHERE id_req=@id_req;", con);
            cmd.Parameters.Add(new SqlParameter("id_req", id_req));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //return Content("Requerimiento Eliminado !exito!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult Actualizar(Int32 id_req)
        {
            //[Vista donde se encuentra el formulario para actualizar]
            List<Requerimiento> modelo = new List<Requerimiento>();
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [Formulario] WHERE id_req=@id_req;", con);
            cmd.Parameters.Add(new SqlParameter("id_req", id_req));
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    modelo.Add(new Requerimiento
                    {
                        id_req = dr.GetInt32(0),
                        gerente_comercial = dr.GetString(1),
                        motivo_req = dr.GetString(2),
                        cliente_nom = dr.GetString(3),
                        gerencia = dr.GetString(4),
                        empresa_cliente = dr.GetString(5),
                        email_cliente = dr.GetString(6),
                        telefono_cliente = dr.GetString(7),
                        perfil_solicitante = dr.GetString(8),
                        carrera_solicitante = dr.GetString(9),
                        nivel_estudios = dr.GetString(10),
                        tiempo_experiencia = dr.GetString(11),
                        catidad_recursos = dr.GetInt32(12),
                        areas_carreras = dr.GetString(13),
                        certificaciones = dr.GetString(14),
                        prioridad_requerimiento = dr.GetString(15),
                        fecha_sol_req = dr.GetDateTime(16),
                        fecha_env_sol = dr.GetDateTime(17),
                        fecha_cierre_req = dr.GetDateTime(18),
                        rango_edad = dr.GetString(19),
                        genero = dr.GetString(20),
                        idiomas = dr.GetString(21),
                        rango_tarifa = dr.GetString(22),
                        rango_sueldo = dr.GetString(23),
                        adicionales = dr.GetString(24),
                        compu_trabajo = dr.GetString(25),
                        compu_trabajo_fecha = dr.GetDateTime(26),
                        redes_sociales = dr.GetString(27),
                        redes_sociales_fecha = dr.GetDateTime(28),
                        pagina_web = dr.GetString(29),
                        pagina_web_fecha = dr.GetDateTime(30),
                        occ_mundial = dr.GetString(31),
                        occ_mundial_fecha = dr.GetDateTime(32)
                    });
                }
                return View(modelo);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult ActualizarRegistro(Int32 id_req)
        {
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"UPDATE [Empleado] SET nombre=@nombre, pApellido=@pApellido, sApellid=@sApellid, telefono=@telefono, 
                                            edad=@edad WHERE id_empleado=@id_empleado;", con);
            cmd.Parameters.Add(new SqlParameter("id_req", id_req));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //return Content("Requerimiento Actualizado !exito!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}