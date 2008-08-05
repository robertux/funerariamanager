using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using CrypterClassLib;


namespace FunerariaClassLib
{
    namespace DataLayer
    {
        public class AccesoDatos
        {
            private MySqlConnection cn;
            private string server;
            private string user;
            private string password;
            private string database;
            private MySqlCommand cmdGetclient;
            private MySqlCommand cmdAddEditclient;
            private MySqlCommand cmdServicios;
            private MySqlCommand cmdAdmin;
            private MySqlCommand cmdPlanPgCuotas;
            private MySqlCommand cmdGastos;
            #region Propiedades

            /// <summary>
            /// Devuelve o establece el nombre del servidor de MySQL al cual se establecerá la conexión. Por defecto se asume el establecido en los settings
            /// </summary>
            public string Servidor
            {
                get { return this.server; }
                set { this.server = (value == "" ? Encriptador.Desencriptar(ConfigurationManager.AppSettings["servidor"],"#IrrJ#") : value); }
            }

            /// <summary>
            /// Devuelve o establece el nombre del usuario de la base de datos de MySQL. Por defecto se asume el configurado en los settings
            /// </summary>
            public string Usuario
            {
                get { return this.user; }
                set { this.user = (value == "" ? Encriptador.Desencriptar(ConfigurationManager.AppSettings["usuario"],"#IrrJ#") : value); }
            }

            /// <summary>
            /// Deuvelve o establece la clave del usuario de la base de datos de MySQL. Por defecto se asume el establecido en los settings
            /// </summary>
            public string Clave
            {
                get { return this.password; }
                set { this.password = (value == "" ? Encriptador.Desencriptar(ConfigurationManager.AppSettings["clave"],"#IrrJ#") : value); }
            }

            /// <summary>
            /// Devuelve o establece el nombre de la base de datos a conectarse. Por defecto se toma la establecida en los settings
            /// </summary>
            public string BaseDatos
            {
                get { return this.database; }
                set { this.database = (value == "" ? Encriptador.Desencriptar(ConfigurationManager.AppSettings["basedatos"],"#IrrJ#") : value); }
            }

            /// <summary>
            /// Devuelve la cadena de conexión generada por los datos del servidor, usuario, clave y base de datos
            /// </summary>
            protected string CadenaConexion
            {
                get
                {
                    return ("server=" + this.Servidor + ";user id=" + this.Usuario +
                    "; password=" + this.Clave + "; database=" + this.BaseDatos + "; pooling=false");
                    
                }
            }

            /// <summary>
            /// Devuelve el estado actual de la conexion con los datos
            /// </summary>
            public ConnectionState Estado
            {
                get
                { return this.cn.State; }
            }
                        
            #endregion

            #region Metodos

            public AccesoDatos(string srv, string bd, string usr, string pwd)
            {
                this.Servidor = srv;
                this.BaseDatos = bd;
                this.Usuario = usr;
                this.Clave = pwd;
                this.cn = new MySqlConnection(this.CadenaConexion);
                this.cmdGetclient = new MySqlCommand("select * from clientes", this.cn);
                this.cmdAddEditclient = new MySqlCommand("",this.cn);
                this.cmdServicios = new MySqlCommand("select * from servicios", this.cn);
                this.cmdAdmin = new MySqlCommand("select * from administradores", this.cn);
                this.cmdPlanPgCuotas = new MySqlCommand("select * from cuotas", this.cn);
                this.cmdGastos = new MySqlCommand("select * from gastos", this.cn);
            }

            public AccesoDatos()
            {
                this.Servidor = "";
                this.BaseDatos = "";
                this.Usuario = "";
                this.Clave = "";
                this.cn = new MySqlConnection(this.CadenaConexion);
                this.cmdGetclient = new MySqlCommand("select * from clientes", this.cn);
                this.cmdAddEditclient = new MySqlCommand("",this.cn);
                this.cmdServicios = new MySqlCommand("select * from servicios", this.cn);
                this.cmdAdmin = new MySqlCommand("select * from administradores", this.cn);
                this.cmdPlanPgCuotas = new MySqlCommand("select * from cuotas", this.cn);
                this.cmdGastos = new MySqlCommand("select * from gastos", this.cn);
            }

            /// <summary>
            /// Abre la conexión con los datos
            /// </summary>
            public void Conectar()
            {
                if (this.Estado != ConnectionState.Open)
                    this.cn.Open();
            }

            /// <summary>
            /// Cierra la conexión con los datos
            /// </summary>
            public void Desconectar()
            {
                this.cn.Close();
            }

            #region Clientes

            /// <summary>
            /// Devuelve un reader que apunta a todos los registros de la tabla clientes
            /// </summary>
            /// <returns></returns>
            public MySqlDataReader GetClientes()
            {
                this.cmdGetclient.CommandText = "select * from clientes";
                return this.cmdGetclient.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un reader de la tabla clientes cuyo codigo coincida con el parametro
            /// </summary>
            /// <param name="codigo">el codigo del cliente a buscar</param>
            /// <returns></returns>
            public MySqlDataReader GetClientes(string codigo)
            {
                this.cmdGetclient.Parameters.Clear();
                this.cmdGetclient.CommandText = "select * from clientes where codigo = ?codigo";
                this.cmdGetclient.Prepare();
                this.cmdGetclient.Parameters.Add("?codigo", codigo);
                return this.cmdGetclient.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un reader de la tabla clientes cuyo estado coincida con el parametro
            /// </summary>
            /// <param name="estado">Estado de los clientes a buscar</param>
            /// <returns></returns>
            public MySqlDataReader GetClientes(long estado)
            {
                this.cmdGetclient.Parameters.Clear();
                this.cmdGetclient.CommandText = "select * from clientes where estado = ?estado";
                this.cmdGetclient.Prepare();
                this.cmdGetclient.Parameters.Add("?estado", estado);
                return this.cmdGetclient.ExecuteReader();
            }

            /// <summary>
            /// Devuelve la cantidad de clientes cuyas iniciales del primer apellido y primer nombre coincidan con los parametros
            /// </summary>
            /// <param name="Apellido">Primer apellido del cliente</param>
            /// <param name="Nombre">Segundo apellido del cliente</param>
            /// <returns></returns>
            public long GetMatchClientes(string Apellido, string Nombre)
            {
                this.cmdGetclient.Parameters.Clear();
                string parametro = Apellido.Substring(0,1) + Nombre.Substring(0,1) + "%";
                this.cmdGetclient.CommandText = "select count(*) from clientes where codigo like ?par";
                this.Conectar();
                this.cmdGetclient.Prepare();
                this.cmdGetclient.Parameters.Add("?par", parametro);
                return (long)this.cmdGetclient.ExecuteScalar();
            }

            /// <summary>
            /// Genera un codigo de cliente basandose en su primer apellido y su nombre pasados en los parametros
            /// </summary>
            /// <param name="Apellido">Primer apellido del cliente</param>
            /// <param name="Nombre">Segundo apellido del cilente</param>
            /// <returns></returns>
            public string GenerarCodigoCliente(string Apellido, string Nombre)
            {
                string existentes = (this.GetMatchClientes(Apellido, Nombre) + 1).ToString().PadLeft(3, '0');
                return (Apellido.Substring(0,1) + Nombre.Substring(0,1) + existentes);
            }

            /// <summary>
            /// Agrega un nuevo cliente a la tabla y devuelve un valor diferente de cero si lo ha agregado
            /// </summary>
            /// <param name="Codigo">El codigo generado para el nuevo cliente</param>
            /// <param name="Apellidos">Los apellidos del cliente</param>
            /// <param name="Nombres">Los nombres del cliente</param>
            /// <param name="Direccion">La direccion del cliente</param>
            /// <param name="Telefono">El numero de telefono del cliente</param>
            /// <param name="Estado">El codigo de estado del cliente</param>
            /// <param name="Tiposerv">El codigo del tipo de servicio del cliente</param>
            /// <returns></returns>
            public long AddClientes(string Codigo, string Apellidos, string Nombres, string Direccion, string Telefono, ulong Estado, string TipoServ)
            {
                this.cmdAddEditclient.Parameters.Clear();
                this.cmdAddEditclient.CommandText = "insert into clientes values( ?codigo, ?apellidos, ?nombres, ?direccion, ?telefono, ?estado, ?servicio)";
                this.cmdAddEditclient.Prepare();
                this.cmdAddEditclient.Parameters.Add("?codigo", Codigo);
                this.cmdAddEditclient.Parameters.Add("?apellidos", Apellidos);
                this.cmdAddEditclient.Parameters.Add("?nombres", Nombres);
                this.cmdAddEditclient.Parameters.Add("?direccion", Direccion);
                this.cmdAddEditclient.Parameters.Add("?telefono", Telefono);
                this.cmdAddEditclient.Parameters.Add("?estado", Estado);
                this.cmdAddEditclient.Parameters.Add("?servicio", TipoServ);
                return this.cmdAddEditclient.ExecuteNonQuery();
            }

            /// <summary>
            /// Actualiza los datos de un cliente existente cuyo codigo coincida con el pasado en el parametro. Devuelve un valor diferente de cero si logro actualizar los datos
            /// </summary>
            /// <param name="Codigo">El codigo del cliente existente en la tabla</param>
            /// <param name="Apellidos">Nuevos apellidos del cliente</param>
            /// <param name="Nombres">Nuevos nombres del cliente</param>
            /// <param name="Direccion">Nueva direccion del cliente</param>
            /// <param name="Telefono">Nuevo telefono del cliente</param>
            /// <param name="Estado">Nuevo codigo del estado del cliente</param>
            /// <param name="Tiposerv">Nuevo codigo del tipo de servicio del cliente</param>
            /// <returns></returns>
            public long EditClientes(string Codigo, string Apellidos, string Nombres, string Direccion, string Telefono, ulong Estado, string TipoServ)
            {
                this.cmdAddEditclient.Parameters.Clear();
                this.cmdAddEditclient.CommandText = "update clientes set apellidos=?apellidos, nombres=?nombres, direccion=?direccion, telefono=?telefono, estado=?estado, tipo_serv=?servicio where codigo = ?codigo";
                this.cmdAddEditclient.Prepare();
                this.cmdAddEditclient.Parameters.Add("?codigo", Codigo);
                this.cmdAddEditclient.Parameters.Add("?apellidos", Apellidos);
                this.cmdAddEditclient.Parameters.Add("?nombres", Nombres);
                this.cmdAddEditclient.Parameters.Add("?direccion", Direccion);
                this.cmdAddEditclient.Parameters.Add("?telefono", Telefono);
                this.cmdAddEditclient.Parameters.Add("?estado", Estado);
                this.cmdAddEditclient.Parameters.Add("?servicio", TipoServ);
                return this.cmdAddEditclient.ExecuteNonQuery();
            }

            /// <summary>
            /// Borra de la tabla el cliente que coincida con el codigo pasado en el parametro
            /// </summary>
            /// <param name="Codigo">Codigo del cliente a boorar</param>
            /// <returns></returns>
            public long DelClientes(string Codigo)
            {
                this.cmdAddEditclient.Parameters.Clear();
                this.cmdAddEditclient.CommandText = "delete from clientes where codigo = ?codigo";
                this.cmdAddEditclient.Prepare();
                this.cmdAddEditclient.Parameters.Add("?codigo", Codigo);
                return this.cmdAddEditclient.ExecuteNonQuery();
            }

            #endregion

            #region Servicios

            /// <summary>
            /// Devuelve un reader que apunta a todos los registros encontrados en la tabla servicios
            /// </summary>
            /// <returns></returns>
            public MySqlDataReader GetServicios()
            {
                this.cmdServicios.CommandText = "select * from servicios";
                return this.cmdServicios.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un reader apuntando al servicio que coincida con el codigo pasado en el parametro
            /// </summary>
            /// <param name="cliente">El codigo del cliente del servicio a buscar</param>
            /// <returns></returns>
            public MySqlDataReader GetServicios(string codigo)
            {
                this.cmdServicios.Parameters.Clear();
                this.cmdServicios.CommandText = "select * from servicios where codigo = ?codigo";
                this.cmdServicios.Prepare();
                this.cmdServicios.Parameters.Add("?codigo", codigo);
                return this.cmdServicios.ExecuteReader();
            }

            /// <summary>
            /// Agrega un nuevo registro a la tabla servicios
            /// </summary>
            /// <param name="codigo">Codigo del nuevo servicio</param>
            /// <param name="nombre">Nombre del nuevo servicio</param>
            /// <param name="descripcion">Descripcion del nuevo servicio</param>
            /// <returns></returns>
            public long AddServicio(string codigo, string nombre, string descripcion)
            {
                this.cmdServicios.Parameters.Clear();
                this.cmdServicios.CommandText = "insert into servicios values(?codigo, ?nombre, ?descripcion)";
                this.cmdServicios.Prepare();
                this.cmdServicios.Parameters.Add("?codigo", codigo);
                this.cmdServicios.Parameters.Add("?nombre", nombre);
                this.cmdServicios.Parameters.Add("?descripcion", descripcion);
                return this.cmdServicios.ExecuteNonQuery();
            }

            /// <summary>
            /// Modifica un servicio existente cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">Codigo del servicio existente</param>
            /// <param name="nombre">Nuevo nombre del servicio</param>
            /// <param name="descripcion">Nueva descripcion del servicio</param>
            /// <returns></returns>
            public long EditServicio(string codigo, string nombre, string descripcion)
            {
                this.cmdServicios.Parameters.Clear();
                this.cmdServicios.CommandText = "update servicios set nombre=?nombre, descripcion=?descripcion where codigo=?codigo";
                this.cmdServicios.Prepare();
                this.cmdServicios.Parameters.Add("?codigo", codigo);
                this.cmdServicios.Parameters.Add("?nombre", nombre);
                this.cmdServicios.Parameters.Add("?descripcion", descripcion);
                return this.cmdServicios.ExecuteNonQuery();
            }

            /// <summary>
            /// Elimina el servicio cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">Codigo del servicio a eliminar</param>
            /// <returns></returns>
            public long DelServicio(string codigo)
            {
                this.cmdServicios.Parameters.Clear();
                this.cmdServicios.CommandText = "delete from servicios where codigo = ?codigo";
                this.cmdServicios.Prepare();
                this.cmdServicios.Parameters.Add("?codigo", codigo);
                return this.cmdServicios.ExecuteNonQuery();
            }

            /// <summary>
            /// Genera un nuevo codigo correlativo para un nuevo servicio
            /// </summary>
            /// <returns></returns>
            public string GenerarCodigoServicio()
            {
                this.cmdServicios.CommandText = "select max(codigo) from servicios";
                this.Conectar();
                long numero = long.Parse((string)this.cmdServicios.ExecuteScalar()) + 1;
                return numero.ToString().PadLeft(5, '0');
            }

            #endregion

            #region Admins

            /// <summary>
            /// Devuelve un reader que apunta a todos los registros de la tabla administradores
            /// </summary>
            /// <returns></returns>
            public MySqlDataReader GetAdmins()
            {
                this.cmdAdmin.CommandText = "select * from administradores";
                return this.cmdAdmin.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un valor booleano indicando si se ha encontrado un administrador que contenga el id y clave pasados en los parametros
            /// </summary>
            /// <param name="id">El id del administrador</param>
            /// <param name="pwd">La clave del administrador</param>
            /// <returns></returns>
            public bool ExisteAdmin(string id, string pwd)
            {
                this.cmdAdmin.Parameters.Clear();
                this.cmdAdmin.CommandText = "select count(*) from administradores where id=?id and clave=?clave";
                this.cmdAdmin.Prepare();
                this.cmdAdmin.Parameters.Add("?id", id);
                this.cmdAdmin.Parameters.Add("?clave", pwd);
                if ((long)this.cmdAdmin.ExecuteScalar() > 0)
                    return true;
                return false;
            }

            /// <summary>
            /// Agrega un nuevo administrador a la tabla de administradores. Devuelve un valor diferente de cero si agrego el registro
            /// </summary>
            /// <param name="id">El id del nuevo administrador</param>
            /// <param name="pwd">La clave del nuevo administrador</param>
            /// <returns></returns>
            public long AddAdmin(string codigo, string id, string pwd)
            {
                this.cmdAdmin.Parameters.Clear();
                this.cmdAdmin.CommandText = "insert into administradores values(?cod, ?id, ?pwd)";
                this.cmdAdmin.Prepare();
                this.cmdAdmin.Parameters.Add("?cod", codigo);
                this.cmdAdmin.Parameters.Add("?id", id);
                this.cmdAdmin.Parameters.Add("pwd", pwd);
                return this.cmdAdmin.ExecuteNonQuery();
            }

            /// <summary>
            /// Modifica la clave del administrador cuyo id coincida con el pasado en el parametro. Devuelve diferente de cero si logro actualizar el registro
            /// </summary>
            /// <param name="id">El id del administrador</param>
            /// <param name="pwd">La nueva clave del administrador</param>
            /// <returns></returns>
            public long EditAdmin(string codigo, string id, string pwd)
            {
                this.cmdAdmin.Parameters.Clear();
                this.cmdAdmin.CommandText = "update administradores set id = ?id, clave = ?clave where codigo = ?cod";
                this.cmdAdmin.Prepare();
                this.cmdAdmin.Parameters.Add("?cod", codigo);
                this.cmdAdmin.Parameters.Add("?id", id);
                this.cmdAdmin.Parameters.Add("?clave", pwd);
                return this.cmdAdmin.ExecuteNonQuery();
            }

            /// <summary>
            /// Elimina el administrador cuyo id coincida con el pasado como parametro
            /// </summary>
            /// <param name="id">El id del administrador a borrar</param>
            /// <returns></returns>
            public long DelAdmin(string codigo)
            {
                this.cmdAdmin.Parameters.Clear();
                this.cmdAdmin.CommandText = "delete from administradores where codigo = ?cod";
                this.cmdAdmin.Prepare();
                this.cmdAdmin.Parameters.Add("?cod", codigo);
                return this.cmdAdmin.ExecuteNonQuery();
            }

            public string GenerarCodigoAdmin()
            {
                this.cmdAdmin.CommandText = "select max(codigo) from administradores";
                this.Conectar();
                long numero = long.Parse((string)this.cmdAdmin.ExecuteScalar()) + 1;
                return numero.ToString().PadLeft(5, '0');
            }

            #endregion

            #region PlanesPagoCuotas

            /// <summary>
            /// Devuelve un reader que apunta a las cuotas cuyo plan de pago coincida con el parametro pasado
            /// </summary>
            /// <param name="planpago">El codigo del plan de pago</param>
            /// <returns></returns>
            public MySqlDataReader GetCuotas(string planpago)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "select * from cuotas where plan_pago = ?plan_pago";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?plan_pago", planpago);
                return this.cmdPlanPgCuotas.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un reader que apunta a un plan de pago cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="cliente">Codigo de plan de pago asignado a un cliente</param>
            /// <returns></returns>
            public MySqlDataReader GetPlanPago(string cliente)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "select * from planes_pago where cliente = ?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", cliente);
                return this.cmdPlanPgCuotas.ExecuteReader();
            }

            /// <summary>
            /// Modifica el campo saldada a verdadero de la cuota cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">Codigo de la cuota a saldar</param>
            /// <returns></returns>
            public long SaldarCuota(string codigo)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "update cuotas set cancelada = 1 where codigo = ?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", codigo);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Agrega un nuevo registro a la tabla cuotas
            /// </summary>
            /// <param name="codigo">Codigo de la nueva cuota</param>
            /// <param name="mes">Mes al que corresponde la nueva cuota</param>
            /// <param name="cantidad">Monto a pagar en la nueva cuota</param>
            /// <param name="fechalimite">Fecha limite a pagar la nueva cuota</param>
            /// <param name="fechapago">Fecha en que sera pagada(ha sido pagada) la nueva cuota</param>
            /// <param name="cancelada">Valor indicativo del estado de la nueva cuota</param>
            /// <param name="planpago">Plan de pago al que corresponde la nueva cuota</param>
            /// <returns></returns>
            public long AddCuota(string codigo, ulong mes, decimal cantidad, DateTime fechalimite, DateTime fechapago, ulong cancelada, string planpago)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "insert into cuotas values(?codigo, ?mes, ?cantidad, ?fechalimite, ?fechapago, ?cancelada, ?planpago)";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", codigo);
                this.cmdPlanPgCuotas.Parameters.Add("?mes", mes);
                this.cmdPlanPgCuotas.Parameters.Add("?cantidad", cantidad);
                this.cmdPlanPgCuotas.Parameters.Add("?fechalimite", fechalimite);
                this.cmdPlanPgCuotas.Parameters.Add("?fechapago", fechapago);
                this.cmdPlanPgCuotas.Parameters.Add("cancelada", cancelada);
                this.cmdPlanPgCuotas.Parameters.Add("planpago", planpago);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Modifica los valores de una cuota existente cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">Codigo de una cuota existente</param>
            /// <param name="mes">Nuevo mes de la cuota</param>
            /// <param name="cantidad">Nuevo monto de la cuota</param>
            /// <param name="fechalimite">Nueva fecha limite de la cuota</param>
            /// <param name="fechapago">Nueva fecha de pago de la cuota</param>
            /// <param name="cancelada">Nuevo estado de cancelacion de la cuota</param>
            /// <param name="planpago">Nuevo plan de pago de la cuota</param>
            /// <returns></returns>
            public long EditCuota(string codigo, ulong mes, decimal cantidad, DateTime fechalimite, DateTime fechapago, ulong cancelada, string planpago)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "update cuotas set mes=?mes, cantidad=?cantidad, fecha_limite=?fechalimite, fecha_pago=?fechapago, cancelada=?cancelada, plan_pago=?planpago where codigo=?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", codigo);
                this.cmdPlanPgCuotas.Parameters.Add("?mes", mes);
                this.cmdPlanPgCuotas.Parameters.Add("?cantidad", cantidad);
                this.cmdPlanPgCuotas.Parameters.Add("?fechalimite", fechalimite);
                this.cmdPlanPgCuotas.Parameters.Add("?fechapago", fechapago);
                this.cmdPlanPgCuotas.Parameters.Add("cancelada", cancelada);
                this.cmdPlanPgCuotas.Parameters.Add("planpago", planpago);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Borra la cuota cuyo codigo coincida con el codigo pasado
            /// </summary>
            /// <param name="codigo">Codigo de la cuota a borrar</param>
            /// <returns></returns>
            public long DelCuota(string codigo)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "delete from cuotas where codigo = ?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", codigo);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Agrega un nuevo registro a la tabla de planes de pago
            /// </summary>
            /// <param name="codigo">El codigo del plan de pago</param>
            /// <param name="ncuotas">El numero de cuotas del plan de pago</param>
            /// <param name="totalpagar">El total a pagar en el plan de pago</param>
            /// <param name="cliente">El codigo del cliente del pland de pago</param>
            /// <returns></returns>
            public long AddPlanPago(string codigo, long ncuotas, decimal totalpagar, string cliente)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "insert into planes_pago values(?codigo, ?ncuotas, ?totalpagar, ?cliente)";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo",codigo);
                this.cmdPlanPgCuotas.Parameters.Add("?ncuotas",ncuotas);
                this.cmdPlanPgCuotas.Parameters.Add("?totalpagar",totalpagar);
                this.cmdPlanPgCuotas.Parameters.Add("?cliente",cliente);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Modifica los datos del plan de pago cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">El codigo del plan de pago a modificar</param>
            /// <param name="ncuotas">El nuevo numero de cuotas</param>
            /// <param name="totalpagar">El nuevo total a pagar</param>
            /// <param name="cliente">El nuevo codigo del cliente</param>
            /// <returns></returns>
            public long EditPlanPago(string codigo, long ncuotas, decimal totalpagar, string cliente)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "update planes_pago set ncuotas=?ncuotas, totalpagar=?totalpagar, cliente=?cliente where codigo=?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo",codigo);
                this.cmdPlanPgCuotas.Parameters.Add("?ncuotas",ncuotas);
                this.cmdPlanPgCuotas.Parameters.Add("?totalpagar",totalpagar);
                this.cmdPlanPgCuotas.Parameters.Add("?cliente",cliente);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Elimina el plan de pago cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">El codigo del plan de pago a eliminar</param>
            /// <returns></returns>
            public long DelPlanPago(string codigo)
            {
                this.cmdPlanPgCuotas.Parameters.Clear();
                this.cmdPlanPgCuotas.CommandText = "delete from planes_pago where codigo = ?codigo";
                this.cmdPlanPgCuotas.Prepare();
                this.cmdPlanPgCuotas.Parameters.Add("?codigo", codigo);
                return this.cmdPlanPgCuotas.ExecuteNonQuery();
            }

            /// <summary>
            /// Genera un codigo correlativo correspondiente a una nueva cuota
            /// </summary>
            /// <returns></returns>
            public string GenerarCodigoCuota()
            {
                this.cmdPlanPgCuotas.CommandText = "select max(codigo) from cuotas";
                this.Conectar();
                long numero = long.Parse((string)this.cmdPlanPgCuotas.ExecuteScalar()) + 1;
                return numero.ToString().PadLeft(5, '0');
            }

            /// <summary>
            /// Genera un codigo correlativo correspondiente a un nuevo plan de pago
            /// </summary>
            /// <returns></returns>
            public string GenerarCodigoPlanPago()
            {
                this.cmdPlanPgCuotas.CommandText = "select max(codigo) from planes_pago";
                this.Conectar();
                long numero = long.Parse((string)this.cmdPlanPgCuotas.ExecuteScalar()) + 1;
                return numero.ToString().PadLeft(5, '0');
            }

            #endregion

            #region Gastos

            /// <summary>
            /// Devuelve un reader que apunta a los registros cuyo tipo coincide con el parametro pasado
            /// </summary>
            /// <param name="tipo">El tipo de gasto</param>
            /// <returns></returns>
            public MySqlDataReader GetGastos(string tipo)
            {
                this.cmdGastos.Parameters.Clear();
                this.cmdGastos.CommandText = "select * from gastos where tipo = ?tipo";
                this.cmdGastos.Parameters.Add("?tipo", tipo);
                return this.cmdGastos.ExecuteReader();
            }

            /// <summary>
            /// Devuelve un reader que apunta a los registros cuya fecha(año y mes) coincide con los parametros pasados
            /// </summary>
            /// <param name="anio">El año del gasto</param>
            /// <param name="mes">El mes del gasto</param>
            /// <returns></returns>
            public MySqlDataReader GetGastos(int anio, int mes)
            {
                this.cmdGastos.Parameters.Clear();
                DateTime mifecha = new DateTime(anio, mes, 1);
                this.cmdGastos.CommandText = "select * from gastos where fecha = ?fecha";
                this.cmdGastos.Parameters.Add("?fecha", mifecha);
                return this.cmdGastos.ExecuteReader();
            }

            /// <summary>
            /// Agrega un nuevo registro a la tabla gastos
            /// </summary>
            /// <param name="codigo">Codigo del nuevo gasto</param>
            /// <param name="tipo">Tipo del nuevo gasto</param>
            /// <param name="concepto">Concepto del nuevo gasto</param>
            /// <param name="monto">Monto del nuevo gasto</param>
            /// <param name="fecha">Fecha del nuevo gasto</param>
            /// <param name="saldado">Estado del saldo del nuevo gasto</param>
            /// <returns></returns>
            public long AddGasto(string codigo, string tipo, string concepto, decimal monto, DateTime fecha, Boolean saldado)
            {
                this.cmdGastos.Parameters.Clear();
                this.cmdGastos.CommandText = "insert into gastos values(?codigo, ?tipo, ?concepto, ?monto, ?fecha, ?saldado)";
                this.cmdGastos.Parameters.Add("?codigo",codigo);
                this.cmdGastos.Parameters.Add("?tipo",tipo);
                this.cmdGastos.Parameters.Add("?concepto",concepto);
                this.cmdGastos.Parameters.Add("?monto",monto);
                this.cmdGastos.Parameters.Add("?fecha",fecha);
                this.cmdGastos.Parameters.Add("?saldado",saldado);
                return this.cmdGastos.ExecuteNonQuery();
            }

            /// <summary>
            /// Modifica un gasto que coincida con el codigo pasado con los nuevos valores pasados en los parametros
            /// </summary>
            /// <param name="codigo">Codigo del gasto existente</param>
            /// <param name="tipo">Nuevo tipo del gasto</param>
            /// <param name="concepto">Nuevo concepto del gasto</param>
            /// <param name="monto">Nuevo monto del gasto</param>
            /// <param name="fecha">Nueva fecha del gasto</param>
            /// <param name="saldado">Nuevo estado de saldo del gasto</param>
            /// <returns></returns>
            public long EditGasto(string codigo, string tipo, string concepto, decimal monto, DateTime fecha, Boolean saldado)
            {
                this.cmdGastos.Parameters.Clear();
                this.cmdGastos.CommandText = "update gastos set tipo=?tipo, concepto=?concepto, monto=?monto, fecha=?fecha, saldado=?saldado where codigo=?codigo";
                this.cmdGastos.Parameters.Add("?codigo", codigo);
                this.cmdGastos.Parameters.Add("?tipo", tipo);
                this.cmdGastos.Parameters.Add("?concepto", concepto);
                this.cmdGastos.Parameters.Add("?monto", monto);
                this.cmdGastos.Parameters.Add("?fecha", fecha);
                this.cmdGastos.Parameters.Add("?saldado", saldado);
                return this.cmdGastos.ExecuteNonQuery();
            }

            /// <summary>
            /// Elimina el registro de la tabla gastos cuyo codigo coincida con el parametro pasado
            /// </summary>
            /// <param name="codigo">Codigo del gasto a eliminar</param>
            /// <returns></returns>
            public long DelGasto(string codigo)
            {
                this.cmdGastos.Parameters.Clear();
                this.cmdGastos.CommandText = "delete from gastos where codigo = ?codigo";
                this.cmdGastos.Parameters.Add("?codigo", codigo);
                this.Conectar();
                return this.cmdGastos.ExecuteNonQuery();
            }

            /// <summary>
            /// Devuelve un codigo correlativo correspondiente a un nuevo gasto
            /// </summary>
            /// <returns></returns>
            public string GenerarCodigoGasto()
            {
                this.cmdGastos.CommandText = "select max(codigo) from gastos";
                this.Conectar();
                long numero = long.Parse((string)this.cmdGastos.ExecuteScalar()) + 1;
                return numero.ToString().PadLeft(5, '0');
            }

            #endregion

            #endregion
        }
    }
}
