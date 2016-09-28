using System;
using Core.GlobalRepository.WsMotor;
using Data.DataCredito.WsMotorService;

namespace Data.DataCredito
{
    public class WsMotorRepository : ServicioMotorService, IWsMotorRepository
    {
        public void UserValidate()
        {
            try
            {
                const string st = "<Solicitud xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                                  "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" tipoIdentificacion=\"1\" " +
                                  "identificacion=\"1023924856\" primerApellido=\"Aguirre\" nitUsuario=\"860034594\" " +
                                  "tipoIdUsuario=\"1\" usuario=\"8888888850\"><Parametros>" +
                                  "<Parametro tipo =\"T\" nombre=\"STRAID\" valor =\"2600\" />" +
                                  "<Parametro tipo =\"T\" nombre=\"STRNAM\" valor =\"SuperSymmetry\" />" +
                                  "<Parametro tipo =\"T\" nombre=\"Ingresos\" valor =\"2000000\" />" +
                                  //"<Parametro tipo =\"T\" nombre=\"Edad\" valor =\"23\" />" +
                                  //"<Parametro tipo =\"T\" nombre=\"Genero\" valor =\"M\" />" +
                                  "</Parametros></Solicitud> ";
                var res = executeStrategy(st);
            }
            catch (Exception exception)
            {

                var a = exception;
            }
            
        }
    }
}
