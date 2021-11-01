using JSON64_Unidad_2.Model;
using JSON64_Unidad_2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JSON64_Unidad_2.ViewModels
{
    public class RegisterViewModel : BaseViewModel<Usuario>
    {
        private Command _registerCommand;
        private string _encrypt;
        private string _jsonResult;
        private UsuarioService usuarioService;
        public RegisterViewModel(Usuario model = null): base(model)
        {
            if (model == null)
            {
                Model = new Usuario();
            }
            usuarioService = new UsuarioService();
        }

        public string Username
        {
            get => Model.Username;
            set
            {
                if (string.Equals(value, Model.Username)) return;
                Model.Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => Model.Password;
            set
            {
                if (string.Equals(value, Model.Password)) return;
                Model.Password = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => Model.Name;
            set
            {
                if (string.Equals(value, Model.Name)) return;
                Model.Name = value;
                OnPropertyChanged();
            }
        }
        public string Ap1
        {
            get => Model.Ap1;
            set
            {
                if (string.Equals(value, Model.Ap1)) return;
                Model.Ap1 = value;
                OnPropertyChanged();
            }
        }
        public string Ap2
        {
            get => Model.Ap2;
            set
            {
                if (string.Equals(value, Model.Ap2)) return;
                Model.Ap2 = value;
                OnPropertyChanged();
            }
        }

        public Command RegisterCommand
        {
            get => _registerCommand ?? (_registerCommand = new Command(RegisterAction));
        }

        private async void RegisterAction()
        {
            Usuario newObject = EncryptOrDecreyptData(true);
            //JsonResult = ModelToJson(newObject);
            JsonResult = await usuarioService.Register(newObject);
        }

        public string Encrypt
        {
            get => _encrypt;
            set
            {
                _encrypt = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Encrypt));
            }
        }

        public string JsonResult
        {
            get => _jsonResult;
            set
            {
                if (string.Equals(_jsonResult, value)) return;
                _jsonResult = value;
                OnPropertyChanged();
            }
        }
    }
}
