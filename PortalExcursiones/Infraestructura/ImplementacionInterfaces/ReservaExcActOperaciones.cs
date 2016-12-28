using PortalExcursiones.Infraestructura.Interfaces;
using PortalExcursiones.Modelos.ModelosEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using CapaDatos.Identity;
using CapaDatos;
using CapaDatos.Entidades;
using PortalExcursiones.Modelos.ModelosSalida;
using System.Data.Entity;
using PortalExcursiones.Infraestructura.Enumeraciones;
using PortalExcursiones.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Hosting;
using System.Configuration;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.Drawing;
using PortalExcursiones.Infraestructura.LogicaComun;
using System.Threading.Tasks;

namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public class ReservaExcActOperaciones : IOperacionesComunes<ReservaExcursionActividadModel>, IOperacionesPasarelaPago, IGeneracionInformes
    {

        private AdministradorUsuario mgr = null;
        private Contexto contexto = null;
        private Respuesta resp = null;

        public ReservaExcActOperaciones(AdministradorUsuario _mgr, Contexto _contexto, Respuesta _resp)
        {
            mgr = _mgr;
            contexto = _contexto;
            resp = _resp;
        }

        public HttpResponseMessage Actualizar(ReservaExcursionActividadModel Entidad, ModelStateDictionary modelo)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Crear(ReservaExcursionActividadModel Entidad, ModelStateDictionary modelo)
        {
            DbContextTransaction tran = null;
            try
            {
                if(!modelo.IsValid)
                {
                    resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                    resp.Objetoerror = modelo;
                    return resp.ObjectoRespuesta();
                }
                var calendario = contexto.calendarioexcursion.Where(x => x.id == Entidad.Calendario_id && x.estadoexcursion.id == (int)EstadoExcursion.activa).FirstOrDefault();
                if(calendario == null)
                {
                    resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                    resp.Mensaje_error = Errores.error14;
                    return resp.ObjectoRespuesta();
                }
                var exact = contexto.excursionactividad.Include("configuracion").Where(x => x.exact_id == calendario.exact_id).FirstOrDefault();
               /* if(exact.esexcursion)
                {
                    if(new TimeSpan((DateTime.UtcNow.Ticks - calendario.fecha.Ticks)).TotalHours < 4)
                    {
                        //error
                    }
                }
                else
                {
                    if (new TimeSpan((DateTime.UtcNow.Ticks - calendario.fecha.Ticks)).TotalHours < 24)
                    {
                        //error
                    }
                }*/
                int total = 0;
                int total_reservados = 0;
                if(exact.secontabilizaninfantes)
                {
                    total = Entidad.Numadultos + Entidad.Numinfantes + Entidad.Numninos + Entidad.Numseniors + Entidad.Numjuniors;
                    if (total == 0)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] {Errores.error30};
                        return resp.ObjectoRespuesta();
                    }
                    var reservas = contexto.reservaexcursionactividad.Where(x => x.calendarioexcursion.exact_id == calendario.exact_id && x.calendarioexcursion.fecha.CompareTo(calendario.fecha) == 0).ToList();
                    if(reservas.Count > 0)
                    {
                        total_reservados = reservas.Sum(x => x.numadultos + x.numinfantes + x.numninos + x.numjuniors + x.numseniors);
                        if(exact.maxpersonas - total_reservados <= 0)
                        {
                            resp.Codigo = (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE);
                            resp.Mensaje_error = Errores.error19;
                            return resp.ObjectoRespuesta();
                        }
                        if ((total + total_reservados) > exact.maxpersonas)
                        {
                            resp.Codigo = (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE);
                            resp.Mensaje_error = String.Format(Errores.error15, (exact.maxpersonas - total_reservados));
                            return resp.ObjectoRespuesta();
                        }
                    }
                }
                else
                {
                    total = Entidad.Numadultos + Entidad.Numninos + Entidad.Numseniors + Entidad.Numjuniors;
                    if(total == 0)
                    {
                        resp.Codigo = (int)Codigos.ERROR_DE_VALIDACION;
                        resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_VALIDACION);
                        resp.Objetoerror = new string[] { Errores.error30 };
                        return resp.ObjectoRespuesta();
                    }
                    var reservas = contexto.reservaexcursionactividad.Where(x => x.calendarioexcursion.exact_id == calendario.exact_id && x.calendarioexcursion.fecha.CompareTo(calendario.fecha) == 0).ToList();
                    if (reservas.Count > 0)
                    {
                        total_reservados = reservas.Sum(x => x.numadultos + x.numninos + x.numjuniors + x.numseniors);
                        if (exact.maxpersonas - total_reservados <= 0)
                        {
                            resp.Codigo = (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE);
                            resp.Mensaje_error = Errores.error19;
                            return resp.ObjectoRespuesta();
                        }
                        if ((total + total_reservados) > exact.maxpersonas)
                        {
                            resp.Codigo = (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.NUMERO_DE_PLAZAS_INSUFICIENTE);
                            resp.Mensaje_error = String.Format(Errores.error15, (exact.maxpersonas - total_reservados));
                            return resp.ObjectoRespuesta();
                        }
                    }
                }
                var precios = contexto.preciotemporada.Where(x => x.exact_id == exact.exact_id).ToList();
                var preciotemp = precios.Where(x => x.id==8).FirstOrDefault();//precios.Where(x => x.desde <= DateTime.UtcNow && DateTime.UtcNow <= x.hasta).FirstOrDefault();
                if (preciotemp == null)
                {
                    resp.Codigo = (int)Codigos.PRECIO_NO_ENCONTRADO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.PRECIO_NO_ENCONTRADO);
                    resp.Mensaje_error = Errores.error17;
                    return resp.ObjectoRespuesta();
                }
                decimal preciofinal;
                if(exact.secontabilizaninfantes)
                {
                     preciofinal = (Entidad.Numadultos * preciotemp.pvpadulto) + (Entidad.Numninos * preciotemp.pvpnino) + (Entidad.Numinfantes * preciotemp.pvpinfante) + (Entidad.Numjuniors * preciotemp.pvpjunior) + (Entidad.Numseniors * preciotemp.pvpsenior);
                }
                else
                {
                     preciofinal = (Entidad.Numadultos * preciotemp.pvpadulto) + (Entidad.Numninos * preciotemp.pvpnino) + (Entidad.Numjuniors * preciotemp.pvpjunior) + (Entidad.Numseniors * preciotemp.pvpsenior);
                }
                decimal descuento = exact.descuento == null ? 0 : (decimal)exact.descuento;
                if(descuento > 0)
                {
                    preciofinal = preciofinal - ((preciofinal * descuento) / 100);
                }
                if(exact.pickupservice)
                {
                    if(Entidad.Punto_id != 0 && Entidad.Punto_id != null)
                    {
                        if(contexto.punto_exact.Where(x => x.exact_id == exact.exact_id && x.punto_id == Entidad.Punto_id).FirstOrDefault() == null)
                        {
                            resp.Codigo = (int)Codigos.REGISTRO_NO_ENCONTRADO;
                            resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.REGISTRO_NO_ENCONTRADO);
                            resp.Mensaje_error = Errores.error21;
                            return resp.ObjectoRespuesta();
                        }
                    }
                }
                else
                    Entidad.Punto_id = null;

                tran = contexto.Database.BeginTransaction();
                var reserva = new reserva();
                reserva.fechatransaccion = DateTime.UtcNow;
                reserva.codigoqr = Guid.NewGuid().ToString();
                reserva.factura = reserva.codigoqr + ".pdf";
                reserva.precio = preciofinal;
                reserva.proveedor_id = exact.configuracion.proveedor_id;
                reserva.cliente_id = Entidad.Cliente_id;
                reserva.colaborador_id = Entidad.Colaborador_id;
                contexto.reserva.Add(reserva);
                contexto.SaveChanges();
                var reservaexact = new reservaexcursionactividad()
                {
                    reserva_id = reserva.id,
                    numadultos = Entidad.Numadultos,
                    numninos = Entidad.Numninos,
                    numinfantes = Entidad.Numinfantes,
                    numjuniors = Entidad.Numjuniors,
                    numseniors = Entidad.Numseniors,
                    direccion = Entidad.Direccion,
                    nombrehotel = Entidad.Nombrehotel,
                    observaciones = Entidad.Observaciones,
                    localidad_id = Entidad.Localidad_id,
                    calendario_id = Entidad.Calendario_id,
                    punto_id = Entidad.Punto_id
                };
                contexto.reservaexcursionactividad.Add(reservaexact);
                if (!RealizarPago())//si el pago ha sido correcto
                {
                    if (contexto.Database.CurrentTransaction != null)
                        tran.Rollback();

                    resp.Codigo = (int)Codigos.ERROR_PASARELA_PAGO;
                    resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_PASARELA_PAGO);
                    resp.Mensaje_error = Errores.error18;
                    return resp.ObjectoRespuesta();
                }
                contexto.SaveChanges();
                tran.Commit();
                Task.Run(() => GenerarFactura(contexto, reserva.codigoqr)).ContinueWith((prevTask) => GestionAvisosEmail.EnviarFacturaReserva(reserva.id, contexto));
                resp.Codigo = (int)Codigos.OK;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.OK);
                return resp.ObjectoRespuesta();
            }
            catch(Exception ex)
            {
                if (contexto.Database.CurrentTransaction != null)
                    tran.Rollback();

                resp.Codigo = (int)Codigos.ERROR_DE_SERVIDOR;
                resp.Mensaje = Enum.GetName(typeof(Codigos), (int)Codigos.ERROR_DE_SERVIDOR);
                resp.Excepcion = Excepcion.Create(ex);
                return resp.ObjectoRespuesta();

            }
        }

        public HttpResponseMessage Todos()
        {
            throw new NotImplementedException();
        }

        public bool RealizarPago()
        {
            //throw new NotImplementedException();
            return true;
        }

        public void GenerarFactura(Contexto contexto,string id)
        {
            var existepuntorecogida = false;
            
            var datosreserva = contexto.reservaexcursionactividad.Include("punto").Where(x => x.reserva.codigoqr == id).Select(x => new
            {
                exact_id = x.calendarioexcursion.exact_id,
                fechatransaccion = x.reserva.fechatransaccion,
                fecha = x.calendarioexcursion.fecha,
                duracion = x.calendarioexcursion.excursionactividad.duracion,
                tipo_duracion = x.calendarioexcursion.excursionactividad.tipoduracion,
                actividad = x.calendarioexcursion.excursionactividad.configuracion.nombre,
                numadultos = x.numadultos,
                numninos = x.numninos,
                numinfantes = x.numinfantes,
                numjuniors = x.numjuniors,
                numseniors = x.numseniors,
                direccion = x.calendarioexcursion.excursionactividad.configuracion.direccion,
                lat = x.calendarioexcursion.excursionactividad.configuracion.lat,
                lng = x.calendarioexcursion.excursionactividad.configuracion.lng,
                descuento = x.calendarioexcursion.excursionactividad.descuento==null ? 0 : x.calendarioexcursion.excursionactividad.descuento,
                punto = x.punto,
                telefono = x.reserva.proveedor.usuario.PhoneNumber,
                nombre = x.reserva.cliente.usuario.nombre,
                primerapellido = x.reserva.cliente.usuario.primerapellido,
                segundoapellido = x.reserva.cliente.usuario.segundoapellido,
                idfactura = x.reserva.id

            }).FirstOrDefault();

            var precios = contexto.preciotemporada.Where(c => (c.desde <= datosreserva.fechatransaccion && datosreserva.fechatransaccion <= c.hasta) && c.exact_id == datosreserva.exact_id).Select(x => new
            {
                precioadulto = x.pvpadulto,
                precionino = x.pvpnino,
                precioinfante = x.pvpinfante,
                preciojunior = x.pvpjunior,
                preciosenior = x.pvpsenior,
                totaladulto = datosreserva.numadultos * x.pvpadulto,
                totaljunior = datosreserva.numjuniors * x.pvpjunior,
                totalsenior = datosreserva.numseniors * x.pvpsenior,
                totalnino = datosreserva.numninos * x.pvpnino,
                totalinfante = datosreserva.numinfantes * x.pvpinfante

            }).FirstOrDefault();

            var facturaitems = contexto.facturaitem_exact.Where(x => x.exact_id == datosreserva.exact_id).Select(x => x.item).ToList();

            if (datosreserva.punto != null)
                 existepuntorecogida = true;
                        
            string filePath = HostingEnvironment.MapPath("~/" + ConfigurationManager.AppSettings["directoriofacturas"] + "/" + id + ".pdf");
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
            iTextSharp.text.Font bold = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
            iTextSharp.text.Font pequeña = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
            iTextSharp.text.Image logocabecera = iTextSharp.text.Image.GetInstance(@"C:\datos\logo.png");
            logocabecera.ScalePercent(15);

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.Color.BLACK);
            cb.MoveTo(38, 720);
            cb.SetLineWidth(0.5f);
            cb.LineTo(doc.PageSize.Width - 38, 720);
            cb.Stroke();

            #region tabla_empresa

            PdfPTable tabla_cabecera_datos_empresa = new PdfPTable(1);

            PdfPCell celda_tabla_cabecera_datos_empresa_nombre = new PdfPCell(new Phrase("EcoTurismo Adventures S.L", fuente));
            PdfPCell celda_tabla_cabecera_datos_empresa_cif = new PdfPCell(new Phrase("B569854122", fuente));
            PdfPCell celda_tabla_cabecera_datos_empresa_telefono = new PdfPCell(new Phrase("(+34) 922 68 32 44", fuente));
            PdfPCell celda_tabla_cabecera_datos_empresa_email = new PdfPCell(new Phrase("info@ecoturismoadv.net", fuente));
            PdfPCell celda_tabla_cabecera_datos_empresa_direccion = new PdfPCell(new Phrase(@"C:\Avenida Bélgica 32006 (Adeje) Santa Cruz de Tenerife, España", fuente));

            tabla_cabecera_datos_empresa.AddCell(celda_tabla_cabecera_datos_empresa_nombre);
            tabla_cabecera_datos_empresa.AddCell(celda_tabla_cabecera_datos_empresa_cif);
            tabla_cabecera_datos_empresa.AddCell(celda_tabla_cabecera_datos_empresa_telefono);
            tabla_cabecera_datos_empresa.AddCell(celda_tabla_cabecera_datos_empresa_email);
            tabla_cabecera_datos_empresa.AddCell(celda_tabla_cabecera_datos_empresa_direccion);
            PdfPCell celda = null;
            foreach (PdfPRow row in tabla_cabecera_datos_empresa.GetRows(0, tabla_cabecera_datos_empresa.Rows.Count))
            {
                foreach (PdfPCell cell in row.GetCells())
                {
                    celda = new PdfPCell(cell.Phrase);
                    celda.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
                    celda.Border = 0;
                    tabla_cabecera_datos_empresa.DeleteRow(0);
                    tabla_cabecera_datos_empresa.AddCell(celda);

                }

            }
            #endregion

            #region tabla_cabecera

            PdfPTable tabla_cabecera = new PdfPTable(2);
            tabla_cabecera.WidthPercentage = 100;
            tabla_cabecera.SetWidths(new float[] { 20, 80 });

            PdfPCell celda_cabecera_logo = new PdfPCell(logocabecera);
            celda_cabecera_logo.Border = 0;

            PdfPCell celda_cabecera_datosempresa = new PdfPCell(tabla_cabecera_datos_empresa);
            celda_cabecera_datosempresa.Border = 0;

            tabla_cabecera.AddCell(celda_cabecera_logo);
            tabla_cabecera.AddCell(celda_cabecera_datosempresa);

            doc.Add(tabla_cabecera);

            #endregion

            #region tabla_precios

            PdfPTable tabla_precios = new PdfPTable(2);
            tabla_precios.WidthPercentage = 100;
            tabla_precios.SetWidths(new float[] { 40, 60 });
            Dictionary<string, string> preciosdic = new Dictionary<string, string>();

            preciosdic.Add(Mensajes.mensaje15, datosreserva.actividad);
            preciosdic.Add(Mensajes.mensaje16, datosreserva.fecha.ToString("dd-MM-yyyy HH:mm:ss"));
            if(datosreserva.tipo_duracion.Equals("flexible"))
            {
                preciosdic.Add(Mensajes.mensaje17, Mensajes.mensaje18);
            }
            else
            {
                var tiempo = "";
                switch(datosreserva.tipo_duracion)
                {
                    case "hora":
                        tiempo = Mensajes.mensaje19;
                    break;
                    case "minuto":
                        tiempo = Mensajes.mensaje20;
                    break;
                    case "dia":
                        tiempo = Mensajes.mensaje21;
                    break;
                }
                preciosdic.Add(Mensajes.mensaje17, datosreserva.duracion.ToString() + " " + tiempo);
            }
            preciosdic.Add(Mensajes.mensaje22,  datosreserva.numadultos.ToString());
            preciosdic.Add(Mensajes.mensaje23,  datosreserva.numjuniors.ToString());
            preciosdic.Add(Mensajes.mensaje24,  datosreserva.numseniors.ToString());
            preciosdic.Add(Mensajes.mensaje25,    datosreserva.numninos.ToString());
            preciosdic.Add(Mensajes.mensaje26, datosreserva.numinfantes.ToString());
            preciosdic.Add(Mensajes.mensaje27,  precios.precioadulto.ToString());
            preciosdic.Add(Mensajes.mensaje28,  precios.preciojunior.ToString());
            preciosdic.Add(Mensajes.mensaje29,  precios.preciosenior.ToString());
            preciosdic.Add(Mensajes.mensaje30,    precios.precionino.ToString());
            preciosdic.Add(Mensajes.mensaje31, precios.precioinfante.ToString());
            preciosdic.Add(Mensajes.mensajes32,  precios.totaladulto.ToString());
            preciosdic.Add(Mensajes.mensajes33,  precios.totaljunior.ToString());
            preciosdic.Add(Mensajes.mensaje34,  precios.totalsenior.ToString());
            preciosdic.Add(Mensajes.mensaje35,    precios.totalnino.ToString());
            preciosdic.Add(Mensajes.mensaje36, precios.totalinfante.ToString());
            PdfPCell cel1 = null;
            foreach (KeyValuePair<string, string> val in preciosdic)
            {
                cel1 = new PdfPCell(new Phrase(val.Key, bold));
                cel1.Border = 0;
                cel1.HorizontalAlignment = PdfCell.ALIGN_LEFT;
                tabla_precios.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase(val.Value, fuente));
                cel1.Border = 0;
                cel1.HorizontalAlignment = PdfCell.ALIGN_LEFT;
                tabla_precios.AddCell(cel1);
            }

            #endregion

            #region tabla_wraper1

            PdfPTable tabla_wraper1 = new PdfPTable(2);
            tabla_wraper1.WidthPercentage = 100;
            tabla_wraper1.SetWidths(new float[] { 70, 30 });
            tabla_wraper1.SpacingBefore = 40f;
            tabla_wraper1.HorizontalAlignment = 0;
            PdfPCell cel2 = new PdfPCell(new Phrase(Mensajes.menaje37 + " " + datosreserva.nombre + " " + datosreserva.primerapellido + " " + datosreserva.segundoapellido, bold));
            cel2.Colspan = 2;
            cel2.PaddingBottom = 5;
            tabla_wraper1.AddCell(cel2);
            tabla_wraper1.AddCell(tabla_precios);

            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var qrCode = qrEncoder.Encode(id);
            var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Four), Brushes.Black, Brushes.White);
            MemoryStream stream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            stream.Position = 0;
            iTextSharp.text.Image output = iTextSharp.text.Image.GetInstance(stream);
            stream.Close();
            tabla_wraper1.AddCell(output);

            doc.Add(tabla_wraper1);

            #endregion

            #region tabla_precio_total

            PdfPTable tabla_precio_total = new PdfPTable(2);
            tabla_precio_total.SetWidths(new float[] { 80, 20 });
            tabla_precio_total.WidthPercentage = 100;
            tabla_precio_total.SpacingBefore = 20;
            tabla_precio_total.HorizontalAlignment = 0;

            PdfPCell celda_tabla_precio_total_nombre = null;

            if (datosreserva.descuento == 0)
                celda_tabla_precio_total_nombre = new PdfPCell(new Phrase(Mensajes.menasje38, fuente));
            else
                celda_tabla_precio_total_nombre = new PdfPCell(new Phrase(String.Format(Mensajes.mensaje39, datosreserva.descuento), fuente));
            
            celda_tabla_precio_total_nombre.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            celda_tabla_precio_total_nombre.BorderWidthRight = 0;
            celda_tabla_precio_total_nombre.PaddingBottom = 5;
            decimal total = (precios.totaladulto + precios.totalinfante + precios.totalnino) - ((precios.totaladulto + precios.totalinfante + precios.totalnino) * ((decimal)datosreserva.descuento / 100));
            PdfPCell celda_tabla_precio_total_precio = new PdfPCell(new Phrase(Math.Round(total,2).ToString() + " €", fuente));
            celda_tabla_precio_total_precio.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            celda_tabla_precio_total_precio.BorderWidthLeft = 0;
            celda_tabla_precio_total_precio.PaddingBottom = 5;

            tabla_precio_total.AddCell(celda_tabla_precio_total_nombre);
            tabla_precio_total.AddCell(celda_tabla_precio_total_precio);

            doc.Add(tabla_precio_total);
            #endregion

            if (existepuntorecogida)
            {
                var datospunto = contexto.puntorecogida.Where(x => x.id == datosreserva.punto.id).Select(x => new
                {

                    pais = x.localidad.provincia.pais.nombre,
                    provincia = x.localidad.provincia.nombre,
                    localidad = x.localidad.nombre,
                    cp = x.localidad.cp
                }).First();
                

                #region tabla_punto

                PdfPTable tabla_punto = new PdfPTable(2);
                tabla_punto.WidthPercentage = 100;
                tabla_punto.SetWidths(new float[] { 20, 80 });
                tabla_punto.SpacingBefore = 20;

                Dictionary<string, string> puntodic = new Dictionary<string, string>();
                puntodic.Add(Mensajes.mensaje9, datosreserva.punto.nombre);
                puntodic.Add(Mensajes.mensaje10, datosreserva.punto.direccion);
                puntodic.Add(Mensajes.mensaje11, datospunto.localidad);
                puntodic.Add(Mensajes.mensaje12, datospunto.provincia);
                puntodic.Add(Mensajes.mensaje13, datospunto.pais);
                puntodic.Add(Mensajes.mensaje14, datospunto.cp.ToString());
                puntodic.Add(Mensajes.mensaje6, String.Format("http://asdadasasd.org?lat={0}&lng={1}", datosreserva.punto.lat, datosreserva.punto.lng));
                PdfPCell cel = null;
                var puntotext = new Phrase(Mensajes.mensaje8, bold);
                cel = new PdfPCell(puntotext);
                cel.Colspan = 2;
                cel.HorizontalAlignment = PdfCell.ALIGN_LEFT;
                cel.PaddingBottom = 10;
                cel.BorderWidthBottom = 0;
                tabla_punto.AddCell(cel);
               foreach (KeyValuePair<string, string> val in puntodic)
                {
                    cel = new PdfPCell(new Phrase(val.Key, bold));
                    cel.BorderWidthBottom = 0;
                    cel.BorderWidthRight = 0;
                    cel.BorderWidthTop = 0;
                    tabla_punto.AddCell(cel);
                    cel = new PdfPCell(new Phrase(val.Value, fuente));
                    cel.BorderWidthBottom = 0;
                    cel.BorderWidthLeft = 0;
                    cel.BorderWidthTop = 0;
                    tabla_punto.AddCell(cel);
                }
                PdfPRow last = tabla_punto.GetRow(tabla_punto.Rows.Count - 1);
                last.GetCells()[0].BorderWidthBottom = 0.5F;
                last.GetCells()[0].PaddingBottom = 5;
                last.GetCells()[1].BorderWidthBottom = 0.5F;
                last.GetCells()[1].PaddingBottom = 5;
                doc.Add(tabla_punto);


                #endregion
            }
            else
            {
                #region tabla_punto

                PdfPTable tabla_punto = new PdfPTable(2);
                tabla_punto.WidthPercentage = 100;
                tabla_punto.SetWidths(new float[] { 20, 80 });
                tabla_punto.SpacingBefore = 20;

                Dictionary<string, string> puntodic = new Dictionary<string, string>();
                puntodic.Add(Mensajes.mensaje5, datosreserva.direccion);
                puntodic.Add(Mensajes.mensaje6, String.Format("http://asdadasasd.org?lat={0}&lng={1}", datosreserva.lat, datosreserva.lng));
                PdfPCell cel = null;
                var puntotext = new Phrase(Mensajes.mensaje7, bold);
                cel = new PdfPCell(puntotext);
                cel.Colspan = 2;
                cel.HorizontalAlignment = PdfCell.ALIGN_LEFT;
                cel.PaddingBottom = 10;
                cel.BorderWidthBottom = 0;
                tabla_punto.AddCell(cel);
                foreach (KeyValuePair<string, string> val in puntodic)
                {
                    cel = new PdfPCell(new Phrase(val.Key, bold));
                    cel.BorderWidthBottom = 0;
                    cel.BorderWidthRight = 0;
                    cel.BorderWidthTop = 0;
                    tabla_punto.AddCell(cel);
                    cel = new PdfPCell(new Phrase(val.Value, fuente));
                    cel.BorderWidthBottom = 0;
                    cel.BorderWidthLeft = 0;
                    cel.BorderWidthTop = 0;
                    tabla_punto.AddCell(cel);
                }
                PdfPRow last = tabla_punto.GetRow(tabla_punto.Rows.Count - 1);
                last.GetCells()[0].BorderWidthBottom = 0.5F;
                last.GetCells()[0].PaddingBottom = 5;
                last.GetCells()[1].BorderWidthBottom = 0.5F;
                last.GetCells()[1].PaddingBottom = 5;
                doc.Add(tabla_punto);

                #endregion
            }

            #region tabla_importante

            PdfPTable tabla_importante = new PdfPTable(1);
            tabla_importante.WidthPercentage = 100;
            tabla_importante.SpacingBefore = 20;

            PdfPCell celda_tabla_importante_importante = new PdfPCell(new Phrase(Mensajes.mensaje3, bold));
            celda_tabla_importante_importante.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            celda_tabla_importante_importante.BorderWidthBottom = 0;
            celda_tabla_importante_importante.PaddingBottom = 10;

            PdfPCell celda_tabla_importante_desc = null;

            if (existepuntorecogida)
                 celda_tabla_importante_desc = new PdfPCell(new Phrase(Mensajes.mensaje2 + " " + datosreserva.telefono, fuente));
            else
                 celda_tabla_importante_desc = new PdfPCell(new Phrase(String.Format(Mensajes.mensaje4, datosreserva.fecha.ToString("dd-MM-yyyy"), datosreserva.fecha.ToString("HH:mm:ss"),datosreserva.telefono), fuente));

            celda_tabla_importante_importante.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            celda_tabla_importante_desc.PaddingBottom = 5;
            celda_tabla_importante_desc.BorderWidthTop = 0;

            tabla_importante.AddCell(celda_tabla_importante_importante);
            tabla_importante.AddCell(celda_tabla_importante_desc);

            doc.Add(tabla_importante);

            #endregion

            #region tabla_condiciones

            PdfPTable tabla_items = new PdfPTable(1);
            tabla_items.WidthPercentage = 100;
            tabla_items.SpacingBefore = 50;

            tabla_items.HorizontalAlignment = 0;

            PdfPCell celda_tabla_items = null;
            foreach (var item in facturaitems)
            {
                celda_tabla_items = new PdfPCell(new Phrase(item.nombre.ToUpper() + ": " + item.descripcion, pequeña));
                celda_tabla_items.HorizontalAlignment = PdfCell.ALIGN_LEFT;
                celda_tabla_items.Border = 0;
                celda_tabla_items.PaddingBottom = 10;
                tabla_items.AddCell(celda_tabla_items);
            }
            
            doc.Add(tabla_items);

            #endregion

            doc.Close();
            writer.Close();

            
        }

        public HttpResponseMessage Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}