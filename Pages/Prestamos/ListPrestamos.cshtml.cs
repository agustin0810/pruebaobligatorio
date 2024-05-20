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
	public class ListPrestamosModel : PageModel
    {
        public List<Prestamo> prestamos;
        public void OnGet()
        {
            this.prestamos = PPrestamo.GetPrestamos();
        }
    }
}
