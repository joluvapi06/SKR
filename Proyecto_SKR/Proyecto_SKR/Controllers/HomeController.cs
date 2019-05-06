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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            log.Info("Ingresaste al Index");
            //[Almacenar la consulta SELECT en la List]
            List<Requerimiento> modelo = new List<Requerimiento>();

            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 id_req, DBO.CleanString(DBO.UpperString(gerente_comercial)), DBO.CleanString(DBO.UpperString(motivo_req)), DBO.CleanString(DBO.UpperString(cliente_nom)),
                    DBO.CleanString(DBO.UpperString(gerencia)), DBO.CleanString(DBO.UpperString(empresa_cliente)), email_cliente, telefono_cliente, DBO.CleanString(DBO.UpperString(perfil_solicitante)),
                    DBO.CleanString(DBO.UpperString(carrera_solicitante)), DBO.CleanString(DBO.UpperString(nivel_estudios)), DBO.CleanString(DBO.UpperString(tiempo_experiencia)),
                    catidad_recursos, DBO.CleanString(DBO.UpperString(areas_carreras)), DBO.CleanString(DBO.UpperString(certificaciones)), prioridad_requerimiento,fecha_sol_req,
                    fecha_env_sol,fecha_cierre_req, DBO.CleanString(DBO.UpperString(rango_edad)), genero, DBO.CleanString(DBO.UpperString(idiomas)), rango_tarifa, rango_sueldo,
                    DBO.CleanString(DBO.UpperString(adicionales)), compu_trabajo, compu_trabajo_fecha, redes_sociales, redes_sociales_fecha, pagina_web, pagina_web_fecha,
                    occ_mundial, occ_mundial_fecha
                    FROM [Formulario] ORDER BY id_req DESC;", con);            
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
            log.Info("Ingreso al formulario");
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
            //Logs del Insert
            log.Info("Id:"+gerente_comercial);
            log.Info("Motivo:"+motivo_req);
            log.Info("Cliente:"+cliente_nom);
            log.Info("GC:"+gerencia);
            log.Info("Empresa:"+empresa_cliente);
            log.Info("Email:"+email_cliente);
            log.Info("Tel:"+telefono_cliente);
            log.Info("Perfil:"+perfil_solicitante);
            log.Info("Carrera:"+carrera_solicitante);
            log.Info("Nivel:"+nivel_estudios);
            log.Info("Tiempo:"+tiempo_experiencia);
            log.Info("#:"+catidad_recursos);
            log.Info("Arreas:"+areas_carreras);
            log.Info("Certificaciones:"+certificaciones);
            log.Info("Prioridad:"+prioridad_requerimiento);
            log.Info("FSol:"+fecha_sol_req);
            log.Info("FEnvi:"+fecha_env_sol);
            log.Info("FCierr:"+fecha_cierre_req);
            log.Info("RE:"+rango_edad);
            log.Info("Genero:"+genero);
            log.Info("Idiomas:"+idiomas);
            log.Info("RT:"+rango_tarifa);
            log.Info("RS:"+rango_sueldo);
            log.Info("Adi:"+adicionales);
            log.Info("CT:"+compu_trabajo);
            log.Info("CTF:"+compu_trabajo_fecha);
            log.Info("SN:"+redes_sociales);
            log.Info("SNF:"+redes_sociales_fecha);
            log.Info("PW:"+pagina_web);
            log.Info("PWF:"+pagina_web_fecha);
            log.Info("OCC:"+occ_mundial);
            log.Info("OCCF:"+occ_mundial_fecha);
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
            log.Info("Ingreso a Consulta por ID.");
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 id_req, DBO.CleanString(DBO.UpperString(gerente_comercial)), DBO.CleanString(DBO.UpperString(motivo_req)), DBO.CleanString(DBO.UpperString(cliente_nom)),
                    DBO.CleanString(DBO.UpperString(gerencia)), DBO.CleanString(DBO.UpperString(empresa_cliente)), email_cliente, telefono_cliente, DBO.CleanString(DBO.UpperString(perfil_solicitante)),
                    DBO.CleanString(DBO.UpperString(carrera_solicitante)), DBO.CleanString(DBO.UpperString(nivel_estudios)), DBO.CleanString(DBO.UpperString(tiempo_experiencia)),
                    catidad_recursos, DBO.CleanString(DBO.UpperString(areas_carreras)), DBO.CleanString(DBO.UpperString(certificaciones)), prioridad_requerimiento,fecha_sol_req,
                    fecha_env_sol,fecha_cierre_req, DBO.CleanString(DBO.UpperString(rango_edad)), genero, DBO.CleanString(DBO.UpperString(idiomas)), rango_tarifa, rango_sueldo,
                    DBO.CleanString(DBO.UpperString(adicionales)), compu_trabajo, compu_trabajo_fecha, redes_sociales, redes_sociales_fecha, pagina_web, pagina_web_fecha,
                    occ_mundial, occ_mundial_fecha
                    FROM [Formulario]  WHERE id_req=@id_req;", con);
            cmd.Parameters.Add(new SqlParameter("id_req", id_req));
            log.Info("ID consultado:"+id_req);
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
            log.Info("Conslta Avanzada."); 
            SqlConnection con = new SqlConnection(@"Data Source=KABEC-PC\SQLEXPRESS; Initial Catalog=SolucionesKabec; User ID=sa; Password=qwerty123");
            string SQL = "SELECT id_req, DBO.CleanString(DBO.UpperString(gerente_comercial)), DBO.CleanString(DBO.UpperString(motivo_req)), DBO.CleanString(DBO.UpperString(cliente_nom)),DBO.CleanString(DBO.UpperString(gerencia)), DBO.CleanString(DBO.UpperString(empresa_cliente)), email_cliente, telefono_cliente, DBO.CleanString(DBO.UpperString(perfil_solicitante)),DBO.CleanString(DBO.UpperString(carrera_solicitante)),DBO.CleanString(DBO.UpperString(nivel_estudios)), DBO.CleanString(DBO.UpperString(tiempo_experiencia)),catidad_recursos, DBO.CleanString(DBO.UpperString(areas_carreras)), DBO.CleanString(DBO.UpperString(certificaciones)), prioridad_requerimiento,fecha_sol_req,fecha_env_sol,fecha_cierre_req, DBO.CleanString(DBO.UpperString(rango_edad)), genero, DBO.CleanString(DBO.UpperString(idiomas)), rango_tarifa, rango_sueldo,DBO.CleanString(DBO.UpperString(adicionales)), compu_trabajo, compu_trabajo_fecha, redes_sociales,redes_sociales_fecha, pagina_web, pagina_web_fecha,occ_mundial, occ_mundial_fecha FROM DBO.Formulario WHERE gerente_comercial LIKE '%"+gerente_comercial+"%' AND cliente_nom LIKE '%"+cliente_nom+"%' AND empresa_cliente LIKE '%"+empresa_cliente+"%' AND perfil_solicitante LIKE '%"+perfil_solicitante+"&';";
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.Add(new SqlParameter("gerente_comercial", gerente_comercial));
            cmd.Parameters.Add(new SqlParameter("cliente_nom", cliente_nom));
            cmd.Parameters.Add(new SqlParameter("empresa_cliente", empresa_cliente));
            cmd.Parameters.Add(new SqlParameter("perfil_solicitante", perfil_solicitante));
            log.Info("Id:" + gerente_comercial);
            log.Info("Cliente:" + cliente_nom);
            log.Info("Empresa:" + empresa_cliente);
            log.Info("Perfil:" + perfil_solicitante);
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
            log.Info("Borraste un Empleado con ID:" + id_req);
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
            log.Info("Busqueda del Empleado con Id:" + id_req + " para actualizarlo");
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