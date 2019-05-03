using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_SKR.Models
{
    public class Requerimiento
    {
        public Int32 id_req { get; set; }
        public String gerente_comercial { get; set; }
        public String motivo_req { get; set; }
        public String cliente_nom { get; set; }
        public String gerencia { get; set; }
        public String empresa_cliente { get; set; }
        public String email_cliente { get; set; }
        public String telefono_cliente { get; set; }
        public String perfil_solicitante { get; set; }
        public String carrera_solicitante { get; set; }
        public String nivel_estudios { get; set; }
        public String tiempo_experiencia { get; set; }
        public Int32 catidad_recursos { get; set; }
        public String areas_carreras { get; set; }
        public String certificaciones { get; set; }
        public String prioridad_requerimiento { get; set; }
        public DateTime fecha_sol_req { get; set; }
        public DateTime fecha_env_sol { get; set; }
        public DateTime fecha_cierre_req { get; set; }
        public String rango_edad { get; set; }
        public String genero { get; set; }
        public String idiomas { get; set; }
        public String rango_tarifa { get; set; }
        public String rango_sueldo { get; set; }
        public String adicionales { get; set; }
        public String compu_trabajo { get; set; }
        public DateTime compu_trabajo_fecha { get; set; }
        public String redes_sociales { get; set; }
        public DateTime redes_sociales_fecha { get; set; }
        public String pagina_web { get; set; }
        public DateTime pagina_web_fecha { get; set; }
        public String occ_mundial { get; set; }
        public DateTime occ_mundial_fecha  { get; set; }
}
}