using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetStore.Entidades
{
    public class Producto
    {
        //[Key]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [StringLength(100, ErrorMessage = "El nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio")]
        [DataType(DataType.Currency)]
        //[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio tiene que ser numérico de maximo 2 decimales")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor ingrese un valor igual o mayor a 0")]
        public decimal Precio { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Fecha creación")]
        public DateTime FechaCreacion { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Fecha edición")]
        public DateTime FechaEdicion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
