using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace FunerariaClassLib
{
    namespace BusinessLayer
    {
        public abstract class CatalogoClientes
        {
            public static List<Cliente> GetClientes()
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetClientes();
                List<Cliente> clientes = new List<Cliente>();
                while (reader.Read())
                    clientes.Add(new Cliente((string)reader["codigo"], (string)reader["apellidos"], (string)reader["nombres"], (string)reader["direccion"], (string)reader["telefono"], (uint)reader["estado"], CatalogoPlanesPago.GetPlan((string)reader["codigo"]) , CatalogoServicios.GetServicios((string)reader["tipo_serv"])));
                datos.Desconectar();
                return clientes;
            }

            public static List<Cliente> GetClientes(int estado)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                List<Cliente> lista = new List<Cliente>();
                datos.Conectar();
                MySqlDataReader reader = datos.GetClientes(estado);
                while(reader.Read())
                    lista.Add(new Cliente((string)reader["codigo"],(string)reader["apellidos"],(string)reader["nombres"],(string)reader["direccion"],(string)reader["telefono"], (uint)reader["estado"], CatalogoPlanesPago.GetPlan((string)reader["codigo"]), CatalogoServicios.GetServicios((string)reader["tipo_serv"])));
                datos.Desconectar();
                return lista;
            }

            public static Cliente GetClientes(string codigo)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetClientes(codigo);
                Cliente cl = new Cliente((string)reader["codigo"], (string)reader["apellidos"], (string)reader["nombres"], (string)reader["direccion"], (string)reader["telefono"], (uint)reader["estado"], CatalogoPlanesPago.GetPlan((string)reader["codigo"]), CatalogoServicios.GetServicios((string)reader["tipo_serv"]));
                datos.Desconectar();
                return cl;
            }

            public static void AddCliente(Cliente client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                string codPlan = datos.GenerarCodigoPlanPago();
                datos.AddClientes(datos.GenerarCodigoCliente(client.Apellidos, client.Nombres), client.Apellidos, client.Nombres, client.Direccion, client.Telefono, client.Estado,client.Serv.Codigo);
                datos.AddPlanPago(codPlan, client.Plan.nCuotas, client.Plan.TotalPagar(), client.Codigo);
                for (int i = 0; (long)i < client.Plan.nCuotas; i++)
                    datos.AddCuota(datos.GenerarCodigoCuota(), client.Plan[i].Mes, client.Plan[i].Cantidad, client.Plan[i].FechaLimite, client.Plan[i].FechaPago, (client.Plan[i].Cancelada == EstadoCuota.Pendiente ? (ulong)0 : (ulong)1), codPlan);
                datos.Desconectar();
            }

            public static void EditCliente(Cliente client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditClientes(client.Codigo, client.Apellidos, client.Nombres, client.Direccion, client.Telefono, client.Estado,client.Serv.Codigo);
                datos.Desconectar();
            }

            public static void DelCliente(Cliente client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelClientes(client.Codigo);
                datos.Desconectar();
            }
        }

        public abstract class CatalogoServicios
        {
            public static List<Servicio> GetServicios()
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetServicios();
                List<Servicio> servicios = new List<Servicio>();
                while (reader.Read())
                    servicios.Add(new Servicio((string)reader["codigo"], (string)reader["nombre"], (string)reader["descripcion"]));
                return servicios;
            }

            public static Servicio GetServicios(string client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                Servicio serv = null;
                datos.Conectar();
                MySqlDataReader reader = datos.GetServicios(client);
                reader.Read();
                if(reader.HasRows)
                    serv = new Servicio((string)reader["codigo"], (string)reader["nombre"], (string)reader["descripcion"]);
                datos.Desconectar();
                return serv;
            }

            public static void AddServicio(Servicio serv)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddServicio(datos.GenerarCodigoServicio(), serv.Nombre, serv.Descripcion);
                datos.Desconectar();
            }

            public static void EditServicio(Servicio serv)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditServicio(serv.Codigo, serv.Nombre, serv.Descripcion);
                datos.Desconectar();
            }

            public static void DelServicio(Servicio serv)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelServicio(serv.Codigo);
                datos.Desconectar();
            }
        }

        public abstract class CatalogoPlanesPago
        {
            public static PlanPago GetPlan(string client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                PlanPago plan = null;
                datos.Conectar();
                MySqlDataReader reader = datos.GetPlanPago(client);
                reader.Read();
                if (reader.HasRows)
                    plan = new PlanPago((string)reader["codigo"], CatalogoCuotas.GetCuotas((string)reader["codigo"]) , (string)reader["cliente"]);
                datos.Desconectar();
                return plan;
            }

            public static void AddPlan(PlanPago plan)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddPlanPago(datos.GenerarCodigoPlanPago(), plan.nCuotas, plan.TotalPagar(), plan.Cliente);
                datos.Desconectar();
            }

            public static void AddPlan(Cliente client)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddPlanPago(datos.GenerarCodigoPlanPago(), client.Plan.nCuotas, client.Plan.TotalPagar(), client.Plan.Cliente);
                datos.Desconectar();
            }

            public static void EditPlan(PlanPago plan)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditPlanPago(plan.Codigo, plan.nCuotas, plan.TotalPagar(), plan.Cliente);
                datos.Desconectar();
            }

            public static void DelPlan(PlanPago plan)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelPlanPago(plan.Codigo);
                datos.Desconectar();
            }
        }

        public abstract class CatalogoCuotas
        {
            public static List<Cuota> GetCuotas(string plan)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetCuotas(plan);
                List<Cuota> lista = new List<Cuota>();
                while (reader.Read())
                    lista.Add(new Cuota((string)reader["codigo"], (uint)reader["mes"], (decimal)reader["cantidad"], (DateTime)reader["fecha_limite"], (reader.IsDBNull(4)? DateTime.MinValue: (DateTime)reader["fecha_pago"]), ((sbyte)reader["cancelada"] == 0 ? EstadoCuota.Pendiente : EstadoCuota.Cancelada)));
                return lista;
            }

            public static void AddCuotas(PlanPago plan)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                for (int i=0; (long)i < plan.nCuotas; i++)
                    datos.AddCuota(datos.GenerarCodigoCuota(), plan[i].Mes, plan[i].Cantidad, plan[i].FechaLimite, plan[i].FechaPago, (plan[i].Cancelada == EstadoCuota.Pendiente ? (uint)0 : (uint)1), plan.Codigo);
                datos.Desconectar();
            }

            public static void AddCuotas(PlanPago plan, int cual)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddCuota(datos.GenerarCodigoCuota(), plan[cual].Mes, plan[cual].Cantidad, plan[cual].FechaLimite, plan[cual].FechaPago, (plan[cual].Cancelada == EstadoCuota.Pendiente ? (uint)0 : (uint)1), plan.Codigo);
                datos.Desconectar();
            }

            public static void EditCuota(PlanPago plan, int cual)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditCuota(plan[cual].Codigo, plan[cual].Mes, plan[cual].Cantidad, plan[cual].FechaLimite, plan[cual].FechaPago, (plan[cual].Cancelada == EstadoCuota.Pendiente ? (uint)0 : (uint)1), plan.Codigo);
                datos.Desconectar();
            }

            public static void Saldar(Cuota ct, PlanPago pl)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditCuota(ct.Codigo, ct.Mes, ct.Cantidad, ct.FechaLimite, DateTime.Now, 1, pl.Codigo);
                datos.Desconectar();
            }

            public static void DelCuota(PlanPago plan, int cual)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelCuota(plan[cual].Codigo);
            }
        }

        public abstract class CatalogoAdmin
        {
            public static string ExisteAdmin(string id, string clave)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = null;
                if (datos.ExisteAdmin(id, clave))
                {
                    reader = datos.GetAdmins();
                    while (reader.Read())
                        if ((string)reader["id"] == id && (string)reader["clave"] == clave)
                            return (string)reader["codigo"];
                }
                return "";
            }

            public static Admin GetAdmin()
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetAdmins();
                Admin adm = null;
                if(reader.Read())
                    adm = new Admin((string)reader["codigo"], (string)reader["id"], (string)reader["clave"]);
                datos.Desconectar();
                return adm;
            }

            public static List<Admin> GetAdmins()
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetAdmins();
                List<Admin> lista = new List<Admin>();
                while(reader.Read())
                    lista.Add(new Admin((string)reader["codigo"], (string)reader["id"], (string)reader["clave"]));
                return lista;
            }

            public static void AddAdmin(Admin adm)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddAdmin(datos.GenerarCodigoAdmin(), adm.Id, adm.Clave);
                datos.Desconectar();
            }

            public static void EditAdmin(Admin adm)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditAdmin(adm.Codigo, adm.Id, adm.Clave);
                datos.Desconectar();
            }

            public static void DelAdmin(Admin adm)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelAdmin(adm.Codigo);
                datos.Desconectar();
            }
        }

        public abstract class CatalogoGastos
        {
            public static List<Gasto> GetGastos(string tipo)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetGastos(tipo);
                List<Gasto> lista = new List<Gasto>();
	            while(reader.Read())
                    lista.Add(new Gasto((string)reader["codigo"],(string)reader["tipo"],(string)reader["concepto"],(decimal)reader["monto"],(DateTime)reader["fecha"],((sbyte)reader["saldado"]==0?false:true)));
                datos.Desconectar();
                return lista;
	        }

            public static List<Gasto> GetGastos(int anio, int mes)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                MySqlDataReader reader = datos.GetGastos(anio,mes);
                List<Gasto> lista = new List<Gasto>();
                while(reader.Read())
                    lista.Add(new Gasto((string)reader["codigo"],(string)reader["tipo"],(string)reader["concepto"],(decimal)reader["monto"],(DateTime)reader["fecha"],((int)reader["saldado"]==0?false:true)));
                datos.Desconectar();
                return lista;
            }

            public static void AddGasto(Gasto gst)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.AddGasto(datos.GenerarCodigoGasto(), gst.Tipo, gst.Concepto, gst.Monto, gst.Fecha, gst.Saldado);
                datos.Desconectar();
            }

            public static void EditGasto(Gasto gst)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.EditGasto(gst.Codigo, gst.Tipo, gst.Concepto, gst.Monto, gst.Fecha, gst.Saldado);
                datos.Desconectar();
            }

            public static void DelGasto(Gasto gst)
            {
                DataLayer.AccesoDatos datos = new DataLayer.AccesoDatos();
                datos.Conectar();
                datos.DelGasto(gst.Codigo);
                datos.Desconectar();
            }
        }
    }
}
