using CapaDatos;
using CapaDatos.Entidades;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using PortalExcursiones.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;


namespace PortalExcursiones.Infraestructura.LogicaComun
{
    public class GestionAvisosEmail
    {
        private Contexto contexto = null;
        private SmtpClient client = null;
        private Dictionary<string, string> datos = null;

        public GestionAvisosEmail(Contexto _contexto)
        {
            this.contexto = _contexto;
            this.datos = new Dictionary<string, string>();
            contexto.clavevalor.Select(x => new { clave = x.clave, valor = x.valor }).ToList().ForEach(x => this.datos.Add(x.clave, x.valor));
            SmtpClient client = new SmtpClient();
            client.Port = Int16.Parse(datos["puertoemail"]);
            client.Host = datos["smtpserver"];
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(datos["emailavisos"], datos["passemailavisos"]);
            this.client = client;
        }

        public void PuntoRecogidaEliminado(long id,List<string>_emailes,string idproveedor)
        {
            var now = DateTime.Now;
            var emailes = _emailes;
            MailMessage msg = null;
            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            var totaldirecciones = "";
            foreach (var direccion in emailes)
            {
                totaldirecciones += direccion + ",";
            }
            totaldirecciones = totaldirecciones.TrimEnd(new char[] { ',' });
            msg = new MailMessage(datos["emailavisos"], totaldirecciones);
            msg.Attachments.Add(logo);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje78.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/PuntoRecogidaEliminado.html"));
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}", String.Format(Mensajes.mensaje77,contexto.Users.Find(idproveedor).PhoneNumber));
            body = body.Replace("{6}", "cid:logo");
            body = body.Replace("{7}", String.Format(Mensajes.mensaje71, contexto.Users.Find(idproveedor).PhoneNumber));
            msg.Body = body;
            client.Send(msg);
        }

        public void PuntoRecogidaModificado(long id)
        {
            var now = DateTime.Now;
            var emailes = contexto.reservaexcursionactividad.Where(x => x.punto_id == id && x.calendarioexcursion.fecha >= now).Select(x => x.reserva.cliente.usuario.Email).ToList();
            var _datos = contexto.puntorecogida.Where(x => x.id == id).Select(x => new
            {
                nombre = x.nombre,
                direccion = x.direccion,
                telefono = x.proveedor.usuario.PhoneNumber,
                localidad = x.localidad.nombre,
                cp = x.localidad.cp,
                pais = x.localidad.provincia.pais.nombre,
                provincia = x.localidad.provincia.nombre,
                lat = x.lat,
                lng = x.lng

            }).First();
            MailMessage msg = null;
            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            var totaldirecciones = "";
            foreach (var direccion in emailes)
            {
                totaldirecciones += direccion + ",";
            }
            totaldirecciones = totaldirecciones.TrimEnd(new char[] { ',' });
            msg = new MailMessage(datos["emailavisos"],totaldirecciones);
            msg.Attachments.Add(logo);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje74.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/PuntoRecogida.html"));
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{6}", Mensajes.mensaje75);
            body = body.Replace("{7}", Mensajes.mensaje76);
            body = body.Replace("{8}", Mensajes.mensaje9);
            body = body.Replace("{9}", _datos.nombre);
            body = body.Replace("{10}", Mensajes.mensaje5);
            body = body.Replace("{11}", _datos.direccion);
            body = body.Replace("{12}", Mensajes.mensaje11);
            body = body.Replace("{13}", _datos.localidad);
            body = body.Replace("{14}", Mensajes.mensaje12);
            body = body.Replace("{15}", _datos.provincia);
            body = body.Replace("{16}", Mensajes.mensaje13);
            body = body.Replace("{17}", _datos.pais);
            body = body.Replace("{18}", Mensajes.mensaje14);
            body = body.Replace("{19}", _datos.cp.ToString());
            body = body.Replace("{20}", Mensajes.mensaje6);
            body = body.Replace("{21}", String.Format(datos["googlemap"], _datos.lat, _datos.lng));
            body = body.Replace("{22}", Mensajes.mensaje65 + " " + _datos.telefono);
            body = body.Replace("{23}", "cid:logo");
            msg.Body = body;
            client.Send(msg);

        }

        public void ExActAnulada(long id)
        {
            var _datos = this.contexto.calendarioexcursion.Where(x => x.id == id).Select(x => new
            {
                nombreact = x.excursionactividad.configuracion.nombre,
                telefono = x.excursionactividad.configuracion.proveedor.usuario.PhoneNumber,
                fecha = x.fecha,
                motivo = x.motivoanulacion

            }).First();

            var direcciones = contexto.reservaexcursionactividad.Where(x => x.calendario_id == id).Select(x => x.reserva.cliente.usuario.Email).ToList<string>();
            var totaldirecciones = "";
            foreach (var direccion in direcciones)
            {
                totaldirecciones += direccion + ",";
            }
            totaldirecciones = totaldirecciones.TrimEnd(new char[] { ',' });
            MailMessage msg = new MailMessage(datos["emailavisos"], totaldirecciones);

            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            msg.Attachments.Add(logo);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje72.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/ExcursionEliminada.html"));
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}", _datos.nombreact.ToUpper());
            body = body.Replace("{6}", String.Format(Mensajes.mensaje68,_datos.fecha.ToString("dd-MM-yyyy HH:mm:ss")));
            body = body.Replace("{8}", String.IsNullOrEmpty(_datos.motivo) ? Mensajes.mensaje73 : _datos.motivo);
            body = body.Replace("{9}", Mensajes.mensaje70);
            body = body.Replace("{10}", String.Format(Mensajes.mensaje71,_datos.telefono));
            body = body.Replace("{11}", "cid:logo");
            msg.Body = body;
            client.Send(msg);
        }

        public void EnviarFacturaReserva(long id)
        {
            var _datos = this.contexto.reservaexcursionactividad.Where(x => x.reserva_id == id).First();
            this.contexto.Configuration.LazyLoadingEnabled = true;
            contexto.Entry(_datos.reserva).Reference("cliente").Load();
            contexto.Entry(_datos.reserva).Reference("proveedor").Load();

            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var qrCode = qrEncoder.Encode(_datos.reserva.codigoqr);
            var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Four), Brushes.Black, Brushes.White);
            MemoryStream stream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            stream.Position = 0;
            
            MailMessage msg = new MailMessage(datos["emailavisos"], _datos.reserva.cliente.usuario.Email);

            Attachment qr = new Attachment(stream, "qr.png", "image/png");
            qr.ContentId = "qrimage";
            qr.ContentDisposition.Inline = true;
            qr.ContentDisposition.DispositionType = "inline; filename=qr.png";
            msg.Attachments.Add(qr);

            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            msg.Attachments.Add(logo);

            string filePath = HostingEnvironment.MapPath("~/" + ConfigurationManager.AppSettings["directoriofacturas"] + "/" + _datos.reserva.factura);
            if (_datos.reserva.proveedor.emailfactura)
            {
                msg.CC.Add(new MailAddress(_datos.reserva.proveedor.usuario.Email));
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje53.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/Reserva.html"));
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}", _datos.calendarioexcursion.excursionactividad.configuracion.nombre.ToUpper());
            body = body.Replace("{6}", _datos.reserva.codigoqr);
            body = body.Replace("{7}", Mensajes.mensaje54);
            body = body.Replace("{8}", _datos.calendarioexcursion.fecha.ToString("dd-MM-yyyy HH:mm:ss"));
            body = body.Replace("{9}", Mensajes.mensaje55);
            body = body.Replace("{10}", _datos.reserva.cliente.usuario.nombre + " " + _datos.reserva.cliente.usuario.primerapellido + " " + _datos.reserva.cliente.usuario.segundoapellido);
            body = body.Replace("{11}", Mensajes.mensaje56);
            body = body.Replace("{12}", (_datos.numadultos + _datos.numjuniors + _datos.numseniors + _datos.numninos).ToString());
            body = body.Replace("{13}", Mensajes.mensaje57);
            body = body.Replace("{14}", _datos.numinfantes.ToString());
            body = body.Replace("{15}", _datos.punto_id == null ? Mensajes.mensaje58.ToUpper() : Mensajes.mensaje59.ToUpper());
            body = body.Replace("{16}", Mensajes.mensaje5);
            body = body.Replace("{17}", _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.direccion : _datos.punto.direccion);
            body = body.Replace("{18}", Mensajes.mensaje11);
            body = body.Replace("{19}", _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.localidad.nombre : _datos.punto.localidad.nombre);
            body = body.Replace("{20}", Mensajes.mensaje12);
            body = body.Replace("{21}", _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.localidad.provincia.nombre : _datos.punto.localidad.provincia.nombre);
            body = body.Replace("{22}", Mensajes.mensaje13);
            body = body.Replace("{23}", _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.localidad.provincia.pais.nombre : _datos.punto.localidad.provincia.pais.nombre);
            body = body.Replace("{24}", Mensajes.mensaje14);
            body = body.Replace("{25}", _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.localidad.cp.ToString() : _datos.punto.localidad.cp.ToString());
            body = body.Replace("{26}", Mensajes.mensaje6);
            var lat = _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.lat : _datos.punto.lat;
            var lng = _datos.punto_id == null ? _datos.calendarioexcursion.excursionactividad.configuracion.lng : _datos.punto.lng;
            body = body.Replace("{27}", String.Format(datos["googlemap"],lat,lng));
            body = body.Replace("{28}", Mensajes.mensaje3);
            body = body.Replace("{29}", Mensajes.mensaje60);
            body = body.Replace("{30}", _datos.reserva.proveedor.usuario.PhoneNumber);
            body = body.Replace("{31}", _datos.punto_id == null ? String.Format(Mensajes.mensaje62,_datos.calendarioexcursion.fecha.ToString("dd-MM-yyyy"), _datos.calendarioexcursion.fecha.ToString("HH:mm:ss")) : Mensajes.mensaje61);
            body = body.Replace("{32}", Mensajes.mensaje17);
            body = body.Replace("{33}", _datos.calendarioexcursion.excursionactividad.duracion == 0 ? _datos.calendarioexcursion.excursionactividad.tipoduracion : _datos.calendarioexcursion.excursionactividad.duracion.ToString());
            body = body.Replace("{34}", "cid:qrimage");
            body = body.Replace("{35}", "cid:logo");

            msg.Attachments.Add(new Attachment(filePath));
            msg.Body = body;
            client.Send(msg);
        }

        public void FechaCalendarioModificada(long id, DateTime fecha)
        {
            var _datos = this.contexto.calendarioexcursion.Where(x => x.id == id).Select(x => new
            {
                nombreact = x.excursionactividad.configuracion.nombre,
                telefono = x.excursionactividad.configuracion.proveedor.usuario.PhoneNumber,
                fecha = x.fecha

            }).First();

            var direcciones = contexto.reservaexcursionactividad.Where(x => x.calendario_id == id).Select(x => x.reserva.cliente.usuario.Email).ToList<string>();
            var totaldirecciones = "";
            foreach (var direccion in direcciones)
            {
                totaldirecciones+= direccion + ",";
            }
            totaldirecciones = totaldirecciones.TrimEnd(new char[] { ',' });
            MailMessage msg = new MailMessage(datos["emailavisos"], totaldirecciones);

            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            msg.Attachments.Add(logo);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje67.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/FechaModificada.html"));
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}",_datos.fecha.ToString("dd-MM-yyyy"));
            body = body.Replace("{6}", _datos.fecha.ToString("HH:mm:ss"));
            body = body.Replace("{7}", Mensajes.mensaje63);
            body = body.Replace("{8}", Mensajes.mensaje64);
            body = body.Replace("{9}", _datos.nombreact.ToUpper());
            body = body.Replace("{10}", _datos.telefono);
            body = body.Replace("{11}", Mensajes.mensaje65);
            body = body.Replace("{12}", String.Format(Mensajes.mensaje66,fecha.ToString("dd-MM-yyyy"), fecha.ToString("HH:mm:ss")));
            body = body.Replace("{13}", "cid:logo");
            msg.Body = body;
            client.Send(msg);
        }

        public void ResetPassword(string id,string password)
        {
            var cliente = this.contexto.Users.Find(id);

            MailMessage msg = new MailMessage(datos["emailavisos"], cliente.Email);

            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            msg.Attachments.Add(logo);

            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje47.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/ResetPassword.html"));
            var nombre = cliente.nombre + " " + cliente.primerapellido + " " + cliente.segundoapellido;
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}", Mensajes.mensaje51);
            body = body.Replace("{6}", Mensajes.mensaje44);
            body = body.Replace("{7}", Mensajes.mensaje45);
            body = body.Replace("{8}", Mensajes.mensaje52);
            body = body.Replace("{9}", cliente.UserName);
            body = body.Replace("{10}", password);
            body = body.Replace("{11}", "cid:logo");
            msg.Body = body;
            client.Send(msg);
        }

        public void CreacionCuentaCliente(string id, string password)
        {
            var cliente = this.contexto.Users.Find(id);

            MailMessage msg = new MailMessage(datos["emailavisos"], cliente.Email);

            FileStream _logo = new FileStream(HostingEnvironment.MapPath("~/recursos/imagenes/logo_empresa.png"), FileMode.Open);
            byte[] dlogo = new byte[_logo.Length];
            _logo.Read(dlogo, 0, dlogo.Length);
            _logo.Close();
            MemoryStream mlogo = new MemoryStream(dlogo);
            Attachment logo = new Attachment(mlogo, "logo.png", "image/png");
            logo.ContentId = "logo";
            logo.ContentDisposition.Inline = true;
            logo.ContentDisposition.DispositionType = "inline; filename=logo.png";
            msg.Attachments.Add(logo);

            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Subject = Mensajes.mensaje46.ToUpper();
            var body = File.ReadAllText(HostingEnvironment.MapPath("~/recursos/html/CreacionCuenta.html"));
            var nombre = cliente.nombre + " " + cliente.primerapellido + " " + cliente.segundoapellido;
            body = body.Replace("{0}", datos["nombre_empresa"]);
            body = body.Replace("{1}", datos["cif"]);
            body = body.Replace("{2}", datos["telefono"]);
            body = body.Replace("{3}", datos["email"]);
            body = body.Replace("{4}", datos["direccion"]);
            body = body.Replace("{5}", Mensajes.mensaje41.ToUpper());
            body = body.Replace("{6}", String.Format(Mensajes.mensaje42, nombre));
            body = body.Replace("{7}", Mensajes.mensaje43);
            body = body.Replace("{8}",  Mensajes.mensaje44);
            body = body.Replace("{9}", Mensajes.mensaje45);
            body = body.Replace("{10}", " " + cliente.UserName);
            body = body.Replace("{11}", " " + password);
            body = body.Replace("{12}", "cid:logo");
            msg.Body = body;
            client.Send(msg);
        }

       
    }
}