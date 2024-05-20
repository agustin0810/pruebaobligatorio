using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using herenciayrelacionesgui.Clases;
using herenciayrelacionesgui.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace herenciayrelacionesgui.Pages.Prestamos
{
	public class AddPrestamosModel : PageModel
    {
        public List<Vehiculo> VehiculosDisponibles = new List<Vehiculo>();
        public void OnGet()
        {
            VehiculosDisponibles = PVehiculo.GetVehiculosDisponibles();
        }

        public async Task<IActionResult> OnGetConseguirCalculoPrecioAsync(string matricula)
        {
            // Obtener el vehículo correspondiente a la matrícula
            Vehiculo V = PVehiculo.GetVehiculo(matricula);

            // Calcular el precio del préstamo
            double precioPrestamo = V.calcularPrestamo();

            // Devolver el precio del préstamo como texto plano
            return Content(precioPrestamo.ToString());
        }

        public IActionResult OnPostAddPrestamo()
        {
            Console.WriteLine(Request.Form["vehiculos"].ToString());
            Prestamo p = new Prestamo(Convert.ToDateTime(Request.Form["fecha"]), PVehiculo.GetVehiculo(Request.Form["vehiculos"].ToString()), Convert.ToDouble(Request.Form["precio"]), Request.Form["cedulacliente"].ToString(), Convert.ToInt32(Request.Form["celularcliente"]));
            PPrestamo.AddPrestamo(p);
            return Redirect("./ListPrestamos");
        }

    }
}
