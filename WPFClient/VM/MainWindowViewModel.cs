using FN738S_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static FN738S_HFT_2023241.Models.House;
using static FN738S_HFT_2023241.Models.Subject;
using static FN738S_HFT_2023241.Models.Teacher;

namespace WPFClient.VM
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;
        static RestService r;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        #region Houses

        public RestCollection<House> Houses { get; set; }

        private House selectedHouse;

        public House SelectedHouse
        {
            get { return selectedHouse; }
            set
            {
                if (value != null)
                {
                    selectedHouse = new House()
                    {
                        ID = value.ID,
                        Founder_name = value.Founder_name,
                        House_name = value.House_name,
                        House_points = value.House_points,

                    };
                    OnPropertyChanged();
                    (DeleteHouseCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateHouseCommand { get; set; }
        public ICommand DeleteHouseCommand {  get; set; }
        public ICommand UpdateHouseCommand {  get; set; }

        #endregion
        #region Students
        public RestCollection<Student> Students { get; set; }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        Id = value.Id,
                        HouseId = value.HouseId,
                        Name = value.Name,
                        Quidditch_player = value.Quidditch_player,

                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        #endregion
        #region Subjects
        public RestCollection<Subject> Subjects { get; set; }

        private Subject selectedSubject;

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (value != null)
                {
                    selectedSubject = new Subject()
                    {
                      Id= value.Id,
                      Subject_Name = value.Subject_Name,


                    };
                    OnPropertyChanged();
                    (DeleteSubjectCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSubjectCommand { get; set; }
        public ICommand DeleteSubjectCommand { get; set; }
        public ICommand UpdateSubjectCommand { get; set; }

        #endregion
        #region Subject_Teachers
        public RestCollection<Subject_teacher> Subject_teachers { get; set; }

        private Subject_teacher selectedSubject_teacher;

        public Subject_teacher SelectedSubject_teacher
        {
            get { return selectedSubject_teacher; }
            set
            {
                if (value != null)
                {
                    selectedSubject_teacher = new Subject_teacher()
                    {
                        Subject_teacher_id = value.Subject_teacher_id,
                        Teacher_ID = value.Teacher_ID,
                        Subject_ID = value.Subject_ID,
                        Year_taught = value.Year_taught,

                    };
                    OnPropertyChanged();
                    (DeleteSubject_teacherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSubject_teacherCommand { get; set; }
        public ICommand DeleteSubject_teacherCommand { get; set; }
        public ICommand UpdateSubject_teacherCommand { get; set; }

        #endregion
        #region Teachers
        public RestCollection<Teacher> Teachers { get; set; }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                      Id = value.Id,
                      Name = value.Name,
                      House_Id = value.House_Id,
                      Animagus = value.Animagus,
                      IsRetired = value.IsRetired,
                    };
                    OnPropertyChanged();
                    (DeleteTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand { get; set; }

        #endregion
        #region NONCRUDS
        public ICommand Subject1Command { get; set; }
        public ICommand Teacher1Command { get; set; }
        public ICommand House1Command { get; set; }
        public ICommand House2Command { get; set; }
        public ICommand House3Command { get; set; }


        //Subject1
        public List<WhoTeachesTheSubject> Subject1Collection {  get; set; }
        public ObservableCollection<WhoTeachesTheSubject> Subject1ObservableCollection { get; set; }

        //Teacher
        public List<WhoIsAnAnimagus> Teacher1Collection { get; set; }
        public ObservableCollection<WhoIsAnAnimagus> Teacher1ObservableCollection { get; set; }
        
        //House
        public List<WhoIsAQuidditchPlayerInTheHouse> House1Collection { get; set; }
        public ObservableCollection<WhoIsAQuidditchPlayerInTheHouse> House1ObservableCollection { get; set; }

        public List<WhoIsARetiredTeacherOfHouse> House2Collection { get; set; }
        public ObservableCollection<WhoIsARetiredTeacherOfHouse> House2ObservableCollection { get; set; }


        public List<WhoIsInTheHouse> House3Collection { get; set; }
        public ObservableCollection<WhoIsInTheHouse> House3ObservableCollection { get; set; }


        #endregion



        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                #region House
                Houses = new RestCollection<House>("http://localhost:3736/", "house", "hub");
                CreateHouseCommand = new RelayCommand(() =>
                {
                    Houses.Add(new House()
                    {

                        House_name = SelectedHouse.House_name,
                        Founder_name = SelectedHouse.Founder_name,
                        House_points = SelectedHouse.House_points,
                        
                    });
                });

                UpdateHouseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Houses.Update(SelectedHouse);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteHouseCommand = new RelayCommand(() =>
                {
                    Houses.Delete(selectedHouse.ID);
                },
                () =>
                {
                    return SelectedHouse != null;
                });
                SelectedHouse = new House();
                #endregion
                #region Student
                Students = new RestCollection<Student>("http://localhost:3736/", "student", "hub");
                CreateStudentCommand = new RelayCommand(() =>
                {
                    Students.Add(new Student()
                    {
                        Id = SelectedStudent.Id,
                       Name = SelectedStudent.Name,
                       HouseId = SelectedHouse.ID,
                       Quidditch_player = SelectedStudent.Quidditch_player,

                    });
                });

                UpdateStudentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Students.Update(SelectedStudent);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(selectedStudent.Id);
                },
                () =>
                {
                    return SelectedStudent != null;
                });
                SelectedStudent = new Student();
                #endregion
                #region Subject
                Subjects = new RestCollection<Subject>("http://localhost:3736/", "subject", "hub");
                CreateSubjectCommand = new RelayCommand(() =>
                {
                    Subjects.Add(new Subject()
                    {
                        Id = SelectedSubject.Id,
                        Subject_Name = SelectedSubject.Subject_Name,
                      
                    });
                });

                UpdateSubjectCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Subjects.Update(SelectedSubject);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSubjectCommand = new RelayCommand(() =>
                {
                    Subjects.Delete(selectedSubject.Id);
                },
                () =>
                {
                    return SelectedSubject != null;
                });
                SelectedSubject = new Subject();
                #endregion
                #region Subject_teacher
                Subject_teachers = new RestCollection<Subject_teacher>("http://localhost:3736/", "subject_teacher", "hub");
                CreateSubject_teacherCommand = new RelayCommand(() =>
                {
                    Subject_teachers.Add(new Subject_teacher()
                    {
                        Subject_teacher_id = SelectedSubject_teacher.Subject_teacher_id,
                        Teacher_ID = SelectedSubject_teacher.Teacher_ID,
                        Subject_ID = SelectedSubject_teacher.Subject_ID,
                        Year_taught = SelectedSubject_teacher.Year_taught

                    });
                });

                UpdateSubject_teacherCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Subject_teachers.Update(SelectedSubject_teacher);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSubject_teacherCommand = new RelayCommand(() =>
                {
                    Subject_teachers.Delete(selectedSubject_teacher.Subject_teacher_id);
                },
                () =>
                {
                    return SelectedSubject_teacher != null;
                });
                SelectedSubject_teacher = new Subject_teacher();
                #endregion
                #region Teacher
                Teachers = new RestCollection<Teacher>("http://localhost:3736/", "teacher", "hub");
                CreateTeacherCommand = new RelayCommand(() =>
                {
                    Teachers.Add(new Teacher()
                    {
                        Id = SelectedTeacher.Id,
                        Name = SelectedTeacher.Name,
                        House_Id = SelectedTeacher.House_Id,
                        Animagus = SelectedTeacher.Animagus,
                        IsRetired = SelectedTeacher.IsRetired,

                    });
                });

                UpdateTeacherCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Teachers.Update(SelectedTeacher);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTeacherCommand = new RelayCommand(() =>
                {
                    Teachers.Delete(selectedTeacher.Id);
                },
                () =>
                {
                    return SelectedTeacher != null;
                });
                SelectedTeacher = new Teacher();
                #endregion
                #region NONCRUDS
                r = new RestService("http://localhost:3736/");

                //Subject1Command
                Subject1ObservableCollection = new ObservableCollection<WhoTeachesTheSubject>();
                Subject1Command = new RelayCommand(() =>
                {
                    Subject1ObservableCollection.Clear();
                    string subjectname = SelectedSubject.Subject_Name;
                    Subject1Collection = r.Get<WhoTeachesTheSubject>(subjectname, "Stat/GetTeacherFromSubject");
                    foreach (var item in Subject1Collection)
                    {
                        Subject1ObservableCollection.Add(item);
                    }
                });

                //Teacher1Command
                Teacher1ObservableCollection = new ObservableCollection<WhoIsAnAnimagus>();
                Teacher1Command = new RelayCommand(() => { 
                
                    Teacher1ObservableCollection.Clear();
                    string subjectname = SelectedSubject.Subject_Name;
                    Teacher1Collection = r.Get<WhoIsAnAnimagus>(subjectname, "Stat/GetAnimagusTeachersFromASubjects");
                    foreach (var item in Teacher1Collection)
                    {
                        Teacher1ObservableCollection.Add(item);
                    }
                });

                //House1Command
                House1ObservableCollection = new ObservableCollection<WhoIsAQuidditchPlayerInTheHouse>();
                House1Command = new RelayCommand(() => { 
                
                    House1ObservableCollection.Clear();
                    string hname = selectedHouse.House_name;
                    House1Collection = r.Get<WhoIsAQuidditchPlayerInTheHouse>(hname, "Stat/GetQuidditchPlayers");
                    foreach (var item in House1Collection)
                    {
                        House1ObservableCollection.Add(item);
                    }
                });

                //House2Command
                House2ObservableCollection = new ObservableCollection<WhoIsARetiredTeacherOfHouse>();
                House2Command = new RelayCommand(() =>
                {
                    House2ObservableCollection.Clear();
                    string hname = SelectedHouse.House_name;
                    House2Collection = r.Get<WhoIsARetiredTeacherOfHouse>(hname, "Stat/GetRetiredTeachersFromHouse");
                    foreach (var item in House2Collection)
                    {
                        House2ObservableCollection.Add(item);
                    }
                });

                //House3Command
                House3ObservableCollection = new ObservableCollection<WhoIsInTheHouse>();
                House3Command = new RelayCommand(() =>
                {
                    House3ObservableCollection.Clear();
                    string hname = SelectedHouse.House_name;
                    House3Collection = r.Get<WhoIsInTheHouse>(hname, "Stat/GetStudentFromHouse");
                    foreach (var item in House3Collection)
                    {
                        House3ObservableCollection.Add(item);
                    }
                });
                #endregion
            }
        }
    }
}
