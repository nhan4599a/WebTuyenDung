using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;
using WebTuyenDung.Attributes;

namespace WebTuyenDung.Conventions
{
    public class ControllerNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNameAttribute = controller.Attributes.OfType<ControllerNameAttribute>().FirstOrDefault();

            if (controllerNameAttribute != null)
            {
                controller.ControllerName = controllerNameAttribute.Name;
            }
        }
    }
}
