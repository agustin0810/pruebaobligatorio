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
	public class ListVehiculosModel : PageModel
    {
        public List<Vehiculo> vehiculos;
        public void OnGet()
        {
            vehiculos = PVehiculo.GetVehiculos();
        }

        public IActionResult OnPostDeleteVehiculo()
        {
            PVehiculo.DeleteVehiculo(Request.Form["matricula"]);
            return Redirect("./ListVehiculos");
        }
    }
}
