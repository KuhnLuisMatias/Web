﻿using Data.Entities;

namespace Web.ViewModels
{
    public class RolesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator RolesViewModel(Roles v)
        {
            var rolViewModel = new RolesViewModel()
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Activo = v.Activo
            };
            return rolViewModel;
        }
    }
}
