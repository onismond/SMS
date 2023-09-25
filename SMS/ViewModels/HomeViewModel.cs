using SMS.Model.Db.Entities;
using SMS.Model.Repositories;
using SMS.Model.Responses;
using SMS.Util;
using SMS.Util.Commands;
using SMS.Util.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SMS.ViewModels
{

    class HomeViewModel : ViewModelBase
    {
        private HomeRepository _repository;
        public ICommand DiscoveryCommand { get; set; }
        //public DiscoveryViewModel DiscoveryVm { get; set; }

        //private object _mainVm;
        //public object MainVm
        //{
        //    get { return _mainVm; }
        //    set { _mainVm = value; }
        //}


        public HomeViewModel(NavigationService<DiscoveryViewModel> discoveryNavigationService, HomeRepository repository)
        {
            _repository = repository;
            //DiscoveryCommand = new NavigateCommand<DiscoveryViewModel>(discoveryNavigationService);
            DiscoveryCommand = new RelayCommand(o =>
            {
                doSomething();
            });
        }

        public async void doSomething()
        {
            //var student = new Student();
            //student.Name = "Student1";
            //student.Location = "Ucc";
            ////await _repository.AddStudent(student);
            ////var AllStudents = await _repository.GetAllStudents();
            //var values = new Dictionary<string, string>();
            //values["email"] = "kofi";
            //values["password"] = "kofi";
            //var response = await _repository.GetUser();
            ////var response = await _repository.PostUser(values);
            //Console.WriteLine(response);
        }
    }
}
