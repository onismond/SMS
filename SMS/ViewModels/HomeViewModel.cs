using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using SMS.Model.Db.Entities;
using SMS.Model.Repositories;
using SMS.Model.Responses;
using SMS.Util;
using SMS.Util.Commands;
using SMS.Util.Services;
using SMS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
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

        static SKColor skRed = new SKColor(237, 128, 217);
        static SKColor skBlue = new SKColor(64, 58, 107);



        public ISeries[] Line1Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Students",
                    Values = new double[] { 2, 2, 4, 5, 5, 7, 7 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Name = "Staff",
                    Values = new double[] { 1, 2, 2, 3, 3, 4, 4 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Name = "Workers",
                    Values = new double[] { 3, 4, 4, 6, 6, 8, 10 },
                    Fill = null
                }
            };

        public IEnumerable<ISeries> Guage1 { get; set; } =
        GaugeGenerator.BuildSolidGauge(
            new GaugeItem(
                40,          // the gauge value
                series =>    // the series style
                {
                    series.Name = "Students";
                    series.MaxRadialColumnWidth = 20;
                    series.DataLabelsSize = 35;
                    series.OuterRadiusOffset = 10;
                    series.InnerRadius = 10;
                    series.Fill = new SolidColorPaint(skRed);
                    series.DataLabelsPaint = new SolidColorPaint(skBlue);
                    series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                }));
        public int Guage1MaxValue => 100;

        public IEnumerable<ISeries> Guage2 { get; set; } =
        GaugeGenerator.BuildSolidGauge(
            new GaugeItem(
                30,          // the gauge value
                series =>    // the series style
                {
                    series.Name = "Staff";
                    series.MaxRadialColumnWidth = 20;
                    series.DataLabelsSize = 35;
                    series.OuterRadiusOffset = 10;
                    series.InnerRadius = 10;
                    series.Fill = new SolidColorPaint(skRed);
                    series.DataLabelsPaint = new SolidColorPaint(skBlue);
                    series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                }));
        public int Guage2MaxValue => 100;

        public IEnumerable<ISeries> Guage3 { get; set; } =
        GaugeGenerator.BuildSolidGauge(
            new GaugeItem(
                60,          // the gauge value
                series =>    // the series style
                {
                    series.Name = "Workers";
                    series.MaxRadialColumnWidth = 20;
                    series.DataLabelsSize = 35;
                    series.OuterRadiusOffset = 10;
                    series.InnerRadius = 10;
                    series.Fill = new SolidColorPaint(skRed);
                    series.DataLabelsPaint = new SolidColorPaint(skBlue);
                    series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                }));
        public int Guage3MaxValue => 100;

        // you can convert any array, list or IEnumerable<T> to a pie series collection:
        public IEnumerable<ISeries> DoughnutSeries { get; set; } =
            new[] { 2, 4, 1, 4, 3 }.AsPieSeries((value, series) =>
            {
                series.InnerRadius = 30;
            });


        private ObservableCollection<ClassObject> todayClasses;

        public ObservableCollection<ClassObject> TodayClasses
        {
            get { return todayClasses; }
            set { todayClasses = value; }
        }

        private ObservableCollection<Reminder> reminders;

        public ObservableCollection<Reminder> Reminders
        {
            get { return reminders; }
            set { reminders = value; }
        }



        public void LoadClasses() {
            for (int i = 0; i <= 5; i++)
            {
                TodayClasses.Add(new ClassObject("Name4", "Location4"));
            }
            
        }
        

        public HomeViewModel(NavigationService<DiscoveryViewModel> discoveryNavigationService, HomeRepository repository)
        {
            _repository = repository;
            todayClasses = new ObservableCollection<ClassObject>();
            TodayClasses.Add(new ClassObject("Name1", "Location1"));
            TodayClasses.Add(new ClassObject("Name2", "Location2"));
            TodayClasses.Add(new ClassObject("Name3", "Location3"));

            reminders = new ObservableCollection<Reminder>();
            Reminders.Add(
                new Reminder { 
                    ReminderTitle = "First Reminder", 
                    ReminderText = "This is what I want to do when I wake up tomorrow morning" 
                });

            Reminders.Add(
                new Reminder
                {
                    ReminderTitle = "Second Reminder",
                    ReminderText = "This is what I want to do when I wake up tomorrow afternoon"
                });

            Reminders.Add(
                new Reminder
                {
                    ReminderTitle = "Third Reminder",
                    ReminderText = "This is what I want to do when I wake up tomorrow evening"
                });

            //DiscoveryCommand = new NavigateCommand<DiscoveryViewModel>(discoveryNavigationService);
            DiscoveryCommand = new RelayCommand(o =>
            {
                doSomething();
            });
            LoadClasses();
        }

        public async void doSomething()
        {
            //LoadClasses();

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
