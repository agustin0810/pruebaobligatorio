using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using herenciayrelacionesgui.Clases;
using herenciayrelacionesgui.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace herenciayrelacionesgui.Pages.Vehiculos
{
	public class UpdateVehiculoModel : PageModel
    {
        public Vehiculo v;
        public void OnGet(string matricula)
        {
            v = PVehiculo.GetVehiculo(matricula);
        }

        public IActionResult OnPostUpdateVehiculo() {

            if (Request.Form["tipo_vehiculo"] == "automovil")
            {
                v = new Automovil(Request.Form["matricula"], Convert.ToDouble(Request.Form["preciomercado"]), true);
            }
            else
            {
                v = new Motocicleta(Request.Form["matricula"], Convert.ToDouble(Request.Form["preciomercado"]), true);
            }

            PVehiculo.UpdateVehiculo(v);
            return Redirect("/Vehiculos/ListVehiculos");
        }
    }
}
