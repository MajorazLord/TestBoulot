using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using TestAffichage.Model;
using TestAffichage.ViewModel;
using Exception = TestAffichage.Model.Exception;

namespace TestAffichage.DataAccess
{
    public class DataBase
    {
        static readonly SqlConnection _conn = new SqlConnection("Database=SAISIE_CONT;Server=s3sql;user=sa;password=Passw0rd");

        private static bool VerifConnection()
        {
            if (MainWindow.IsConnected())
            {
                return true;
            }
            MessageBox.Show("Erreur ! Merci de bien vouloir connecter le support au réseau WIFI", "ERREUR WIFI", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            return false;
        }

        #region Lecture des Secteurs dans la table SECTEURS
        public static List<SecteurVM> GetsSecteursBDD(string site)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "SELECT * FROM SECTEURS WHERE SITE = @site"
                };
                cmd.Parameters.AddWithValue("@site", site);

                SqlDataReader dataReader = cmd.ExecuteReader();
                List<SecteurVM> listSect = new List<SecteurVM>();
                while (dataReader.Read())
                {
                    listSect.Add(new SecteurVM(
                        new Secteur(dataReader[0].ToString(), dataReader[1].ToString(), new List<PosteDeCharge>())));
                }

                _conn.Close(); // Close the connection
                return listSect;
            }
            return new List<SecteurVM>();
        }
        #endregion

        #region Lecture des Secteurs dans la table SECTEURS
        public static List<SecteurVM> GetsAllSecteursBDD()
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "SELECT * FROM SECTEURS"
                };

                SqlDataReader dataReader = cmd.ExecuteReader();
                List<SecteurVM> listSect = new List<SecteurVM>();
                while (dataReader.Read())
                {
                    listSect.Add(new SecteurVM(
                        new Secteur(dataReader[0].ToString(), dataReader[1].ToString(), new List<PosteDeCharge>())));
                }

                _conn.Close(); // Close the connection
                return listSect;
            }
            return new List<SecteurVM>();
        }
        #endregion

        #region Verification Si ADD or UPDATE
        public static string VerifAddOrUpdate(List<SaisieVM> saisieToSave)
        {
            string res = "";
            PosteDeCharge pdcTest;
            foreach (SaisieVM saisieVm in saisieToSave)
            {
                if (saisieVm.PdcsNonPrésents.Count != 0)
                {
                    pdcTest = saisieVm.PdcsNonPrésents[0];
                }
                else
                {
                    pdcTest = saisieVm.PdcsPrésents[0];
                }
                
                if (VerifConnection())
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = _conn,
                        CommandText = "SELECT COUNT(*) FROM POSTE_CHARGE_PRESENCE WHERE POSTE_CHARGE = @pdc AND DATE = @date AND EQUIPE = @equipe"
                    };
                    cmd.Parameters.AddWithValue("@pdc", pdcTest.Code);
                    cmd.Parameters.AddWithValue("@date", saisieVm.JourSaisie.Date);
                    cmd.Parameters.AddWithValue("@equipe", saisieVm.Horaire);
                    
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        res = dataReader[0].ToString();
                    }
                    _conn.Close(); // Close the connection
                }
            }
            if (res == "0")
            {
                return "add";
            }
            return "update";
        }
        #endregion
        
        #region Lecture des postes de charges dans la table POSTE_CHARGE
        public static List<PosteDeCharge> GetsPosteDeChargesBDD(Secteur secteur)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "SELECT * FROM POSTE_CHARGE WHERE SECTEUR = @secteur"
                };
                cmd.Parameters.AddWithValue("@secteur", secteur.Code);

                SqlDataReader dataReader = cmd.ExecuteReader();
                List<PosteDeCharge> listPoste = new List<PosteDeCharge>();
                while (dataReader.Read())
                {
                    listPoste.Add(new PosteDeCharge(dataReader[0].ToString(), dataReader[1].ToString(),
                        new List<Machine>()));
                }

                _conn.Close(); // Close the connection
                return listPoste;
            }
            return new List<PosteDeCharge>();
        }
        #endregion
        
        #region Lecture des machines dans la table MACHINES
        public static List<Machine> GetsMachinesBDD(PosteDeCharge pdc)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "SELECT * FROM MACHINES WHERE POSTE_CHARGE = @pdc"
                };
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);

                SqlDataReader dataReader = cmd.ExecuteReader();
                List<Machine> listPoste = new List<Machine>();
                while (dataReader.Read())
                {
                    listPoste.Add(new Machine(dataReader[0].ToString(), dataReader[1].ToString(),
                        new List<Indisponibilité>(), new List<Exception>(), "", 0));
                }

                _conn.Close(); // Close the connection
                return listPoste;
            }
            return new List<Machine>();
        }
        #endregion

        #region DeleteTablePresenceTR
        public static void DeleteTablePresenceTR()
        {
            _conn.Open();
            SqlCommand cmd1 = new SqlCommand
            {
                Connection = _conn,
                CommandText = "DELETE FROM PDC_PRESENCE_TEMPSREEL"
            };
            cmd1.ExecuteNonQuery();
            _conn.Close();
        }
        #endregion

        #region SaveSaisieInBDD

        public static bool SaveSaisieVMToBDD_TR(List<SaisieVM> saisieToSave, string methode)
        {
            DateTime newDate = saisieToSave[0].JourSaisie;
            DateTime baseDate = new DateTime(1,1,1,1,1,1);
            string baseEquipe = "";
            string newEquipe = saisieToSave[0].Horaire;
            _conn.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = _conn,
                CommandText = "SELECT TOP 1 DATE, EQUIPE FROM PDC_PRESENCE_TEMPSREEL"
            };

            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                baseDate = (DateTime) dataReader[0];
                baseEquipe = (string) dataReader[1];
            }
            _conn.Close(); // Close the connection

            //Rien n'est lu dans la table, on ajoute juste la saisie
            if (baseDate == new DateTime(1, 1, 1, 1, 1, 1))
            {
                SaveSaisieVMToBDD(saisieToSave, "add");
                return true;
            }

            if (newDate.Day == baseDate.Day)
            {
                if (baseEquipe == newEquipe)
                {
                    string res = "";
                    res = VerifAddOrUpdate(saisieToSave);
                    SaveSaisieVMToBDD(saisieToSave, res);
                    //TODO /!\ Add ou UPDATE saisieToSave dans la table PDC_PRESENCE_TEMPSREEL comme dans le truc de dessous /!\
                }
                else
                {
                    DeleteTablePresenceTR();
                    SaveSaisieVMToBDD(saisieToSave, "add");
                    return true;
                }
            }
            else
            {
                DeleteTablePresenceTR();
                SaveSaisieVMToBDD(saisieToSave, "add");
                return true;  
            }
            return true;
        }


        public static bool SaveSaisieVMToBDD(List<SaisieVM> saisieToSave, string methode)
        {
            if (VerifConnection())
            {
                _conn.Open();
                foreach (SaisieVM saisie in saisieToSave)
                {
                    List<PosteDeCharge> listNoPresentToSave = saisie.PdcsNonPrésents;
                    List<PosteDeCharge> listPresentToSave = saisie.PdcsPrésents;
                    List<PosteDeCharge> listNoSaisieToSave = saisie.PdcsNonSaisie;

                    if (methode == "add")
                    {
                        if (listPresentToSave.Count != 0)
                        {
                            SavePresent(listPresentToSave, saisie.Horaire, saisie.JourSaisie.Date);
                        }
                        if (listNoPresentToSave.Count != 0)
                        {
                            SaveNoPresent(listNoPresentToSave, saisie.Horaire, saisie.JourSaisie.Date);
                        }
                        if (listNoSaisieToSave.Count != 0)
                        {
                            SaveNoSaisie(listNoSaisieToSave, saisie.Horaire, saisie.JourSaisie.Date);
                        }
                        _conn.Close();
                        return true;
                    }
                    if (methode == "update")
                    {
                        MessageBoxResult x = MessageBox.Show(
                            "Vous êtes sur le point de modifier une saisie existante (jour et poste identique). Êtes-vous sur de vouloir continuer ?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (x == MessageBoxResult.Yes)
                        {
                            if (listPresentToSave.Count != 0)
                            {
                                UpdatePresent(listPresentToSave, saisie.Horaire, saisie.JourSaisie.Date);
                            }
                            if (listNoPresentToSave.Count != 0)
                            {
                                UpdateNoPresent(listNoPresentToSave, saisie.Horaire, saisie.JourSaisie.Date);
                            }
                            if (listNoSaisieToSave.Count != 0)
                            {
                                UpdateNoSaisie(listNoSaisieToSave, saisie.Horaire, saisie.JourSaisie.Date);
                            }

                            _conn.Close();
                            return true;
                        }
                        _conn.Close();
                        return false;
                    }
                }
                _conn.Close();
            }
            return false;
        }
        #endregion

        #region SavePresent
        private static void SavePresent(List<PosteDeCharge> pdcPresentToSave, string horaire, DateTime jourSaisie)
        {
            foreach (PosteDeCharge pdc in pdcPresentToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "INSERT INTO PDC_PRESENCE_TEMPSREEL (POSTE_CHARGE, DATE, EQUIPE, PRESENT) VALUES (@pdc, @date, @equipe, @present)"
                };
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", 1);
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region SaveNoPresent
        private static void SaveNoPresent(List<PosteDeCharge> pdcNoPresentToSave, string horaire, DateTime jourSaisie)
        {
            foreach (PosteDeCharge pdc in pdcNoPresentToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "INSERT INTO PDC_PRESENCE_TEMPSREEL (POSTE_CHARGE, DATE, EQUIPE, PRESENT) VALUES (@pdc, @date, @equipe, @present)"
                };

                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", 0);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        
        #region SaveNoSaisie
        private static void SaveNoSaisie(List<PosteDeCharge> pdcNoSaisieToSave, string horaire, DateTime jourSaisie)
        {
            foreach (PosteDeCharge pdc in pdcNoSaisieToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "INSERT INTO PDC_PRESENCE_TEMPSREEL (POSTE_CHARGE, DATE, EQUIPE, PRESENT) VALUES (@pdc, @date, @equipe, @present)"
                };
            
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", -1);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        
        #region UpdatePresent
        private static void UpdatePresent(List<PosteDeCharge> pdcPresentToSave, string horaire, DateTime jourSaisie)
        {
            foreach (PosteDeCharge pdc in pdcPresentToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "UPDATE PDC_PRESENCE_TEMPSREEL SET PRESENT = @present WHERE POSTE_CHARGE = @pdc AND DATE = @date AND EQUIPE = @equipe"
                };
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", 1);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region UpdateNoPresent
        private static void UpdateNoPresent(List<PosteDeCharge> pdcNoPresentToSave, string horaire, DateTime jourSaisie)
        {
            foreach (PosteDeCharge pdc in pdcNoPresentToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "UPDATE PDC_PRESENCE_TEMPSREEL SET PRESENT = @present WHERE POSTE_CHARGE = @pdc AND DATE = @date AND EQUIPE = @equipe"
                };
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", 0);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        
        #region UpdateNoSaisie
        private static void UpdateNoSaisie(List<PosteDeCharge> pdcNoSaisieToSave, string horaire, DateTime jourSaisie)
        {
            bool? valTest = null;
            foreach (PosteDeCharge pdc in pdcNoSaisieToSave)
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText = "UPDATE PDC_PRESENCE_TEMPSREEL SET PRESENT = @present WHERE POSTE_CHARGE = @pdc AND DATE = @date AND EQUIPE = @equipe"
                };
                cmd.Parameters.AddWithValue("@pdc", pdc.Code);
                cmd.Parameters.AddWithValue("@date", jourSaisie);
                cmd.Parameters.AddWithValue("@equipe", horaire);
                cmd.Parameters.AddWithValue("@present", -1);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region SaveException
        public static void SaveExceptionInBDD(List<ExceptionVM> lesExceptionsToSave)
        {
            if (VerifConnection())
            {
                _conn.Open();
                foreach (ExceptionVM evm in lesExceptionsToSave)
                {
                    foreach (MachineVM machineVm in evm.LesMachines)
                    {
                        float ligne = -(DetermineNoLigne(evm) + 1);

                        float duree = 0;
                        if (evm.HeureF > evm.HeureD)
                        {
                            duree = (float) Math.Round((evm.HeureF - evm.HeureD).TotalMinutes/60,2);
                        }
                        else
                        {
                            duree = (float)Math.Round(24 - evm.HeureD.TotalMinutes/60 + evm.HeureF.TotalMinutes/60);
                        }

                        int jour = 0;
                        if (evm.Date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            jour = 7;
                        }
                        else
                        {
                            jour = (int)evm.Date.DayOfWeek;
                        }

                        SqlCommand cmd = new SqlCommand
                        {
                            Connection = _conn,
                            CommandText =
                                "INSERT INTO MACHINES_CALENDRIER (NOMACHINE, DATE, EQUIPE, HEURE_DEB, HEURE_FIN, DUREE, CREAT_FICHE_MANQ, JOUR, NOLIGNE) VALUES (@nomachine, @date, @equipe, @heure_deb, @heure_fin, @duree, @creat, @jour, @noligne)"
                        };
                        
                        cmd.Parameters.AddWithValue("@nomachine", machineVm.NoMachine);
                        cmd.Parameters.AddWithValue("@date", evm.Date.Date);
                        cmd.Parameters.AddWithValue("@equipe", evm.Poste);
                        cmd.Parameters.AddWithValue("@heure_deb", Math.Round(evm.HeureD.TotalMinutes / 60,2));
                        cmd.Parameters.AddWithValue("@heure_fin", Math.Round(evm.HeureF.TotalMinutes / 60,2));
                        cmd.Parameters.AddWithValue("@duree", duree);
                        cmd.Parameters.AddWithValue("@creat", "N");
                        cmd.Parameters.AddWithValue("@jour", jour);
                        cmd.Parameters.AddWithValue("@noligne", ligne);
                        cmd.ExecuteNonQuery();
                    }
                }
                _conn.Close();
            }
        }

        public static int DetermineNoLigne(ExceptionVM exception)
        {
            int res = 0;
            SqlCommand cmd = new SqlCommand
            {
                Connection = _conn,
                CommandText =
                    "SELECT COUNT(*) FROM MACHINES_CALENDRIER WHERE DATE = @date AND NOMACHINE != @nomachine"
            };
            cmd.Parameters.AddWithValue("@date", exception.Date.Date);
            cmd.Parameters.AddWithValue("@nomachine", "");

            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                res = (int)dataReader[0];
            }
            dataReader.Close();
            return res;
        }

        /*public static void ResetCalendrier()
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = _conn,
                CommandText =
                    "DELETE FROM MACHINES_CALENDRIER WHERE NOMACHINE != @nomachine"
            };
            cmd.Parameters.AddWithValue("@nomachine", "");

            cmd.ExecuteNonQuery();
            _conn.Close();
        }
        */
        #endregion

        #region DeleteElementAAfficher
        public static void DeleteElementAAfficher(AffichableEnListeBox elemToDelete)
        {
            if (elemToDelete is ExceptionUVM)
            {
                ExceptionUVM excepts = elemToDelete as ExceptionUVM;
                if (VerifConnection())
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = _conn,
                        CommandText = "DELETE FROM MACHINES_CALENDRIER WHERE NOMACHINE = @nomachine AND DATE = @date AND EQUIPE = @equipe"
                    };
                    cmd.Parameters.AddWithValue("@nomachine", excepts.NoMachine);
                    cmd.Parameters.AddWithValue("@date", excepts.Date.Date);
                    cmd.Parameters.AddWithValue("@equipe", excepts.Poste);

                    cmd.ExecuteNonQuery();
                    _conn.Close(); // Close the connection
                }
            }
            if (elemToDelete is IndisponibilitéVM)
            {
                IndisponibilitéVM indispo = elemToDelete as IndisponibilitéVM;
                if (VerifConnection())
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = _conn,
                        CommandText = "DELETE FROM MACHINES_INDISPO WHERE NOMACHINE = @nomachine AND DATE_DEBUT = @dateDeb AND DATE_FIN = @dateFin AND COMMENTAIRE = @commentaire AND REQUISE = @requise"
                    };
                    cmd.Parameters.AddWithValue("@nomachine", indispo.NoMachineIndispo);
                    cmd.Parameters.AddWithValue("@dateDeb", indispo.DateSaisieD);
                    cmd.Parameters.AddWithValue("@dateFin", indispo.DateSaisieF);
                    cmd.Parameters.AddWithValue("@commentaire", indispo.Commentaire);
                    cmd.Parameters.AddWithValue("@requise", indispo.Requise);
                    cmd.ExecuteNonQuery();
                    _conn.Close(); // Close the connection
                }
            }
        }
        #endregion

        #region SaveIndispo
        public static void SaveIndispo(IndisponibilitéVM indispoToSave)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "INSERT INTO MACHINES_INDISPO (NOMACHINE, DATE_DEBUT, DATE_FIN, COMMENTAIRE, REQUISE) VALUES (@nomachine, @dateDeb, @dateFin, @commentaire, @requise)"
                };

                cmd.Parameters.AddWithValue("@nomachine", indispoToSave.NoMachineIndispo);
                cmd.Parameters.AddWithValue("@dateDeb", indispoToSave.DateSaisieD);
                cmd.Parameters.AddWithValue("@dateFin", indispoToSave.DateSaisieF);
                cmd.Parameters.AddWithValue("@commentaire", indispoToSave.Commentaire);
                cmd.Parameters.AddWithValue("@requise", indispoToSave.Requise);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }
        #endregion

        #region ChargerIndiposDepuisBDD
        public static ObservableCollection<AffichableEnListeBox> ChargerIndisposDepuisBDD()
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "SELECT * FROM MACHINES_INDISPO"
                };

                SqlDataReader dataReader = cmd.ExecuteReader();
                ObservableCollection<AffichableEnListeBox> listIndispo = new ObservableCollection<AffichableEnListeBox>();
                while (dataReader.Read())
                {
                    Debug.WriteLine(dataReader[1].ToString());
                    listIndispo.Add(new IndisponibilitéVM(dataReader[0].ToString(), BddToDataTime(dataReader[1].ToString()), BddToDataTime(dataReader[2].ToString()), (bool)dataReader[4], dataReader[3].ToString()));
                }
                _conn.Close();
                return listIndispo;
            }
            return new ObservableCollection<AffichableEnListeBox>();
        }
        #endregion
        
        #region ChargerExceptsDepuisBDD
        public static ObservableCollection<AffichableEnListeBox> ChargerExceptsDepuisBDD()
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "SELECT * FROM MACHINES_CALENDRIER WHERE NOMACHINE != @nomachine"
                };
                cmd.Parameters.AddWithValue("@nomachine", "");

                SqlDataReader dataReader = cmd.ExecuteReader();
                ObservableCollection<AffichableEnListeBox> listExcepts = new ObservableCollection<AffichableEnListeBox>();
                while (dataReader.Read())
                {
                    listExcepts.Add(new ExceptionUVM(dataReader[0].ToString(), BddToDataTime(dataReader[1].ToString()), dataReader[2].ToString(), BddToHours(dataReader[3].ToString()), BddToHours(dataReader[4].ToString())));
                }
                _conn.Close();
                return listExcepts;
            }
            return new ObservableCollection<AffichableEnListeBox>();
        }
        #endregion

        #region ChargerIndispos+Excepts
        public static ObservableCollection<AffichableEnListeBox> ChargerIndisposExcepts()
        {
            ObservableCollection<AffichableEnListeBox> res = ChargerIndisposDepuisBDD();
            ObservableCollection<AffichableEnListeBox> res2 = ChargerExceptsDepuisBDD();
            foreach (AffichableEnListeBox elem in res2)
            {
                res.Add(elem);
            }
            return res;
        }
        #endregion

        #region ChargeIndispoDate
        public static ObservableCollection<AffichableEnListeBox> ChargeIndispoDate(DateTime dateJour)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "SELECT * FROM MACHINES_INDISPO WHERE @dateJour >= DATE_DEBUT AND DATE_FIN >= @dateJour"
                };
                cmd.Parameters.AddWithValue("@dateJour", dateJour);

                SqlDataReader dataReader = cmd.ExecuteReader();
                ObservableCollection<AffichableEnListeBox> listIndispo = new ObservableCollection<AffichableEnListeBox>();
                while (dataReader.Read())
                {
                    //Debug.WriteLine(dataReader[1].ToString());
                    listIndispo.Add(new IndisponibilitéVM(dataReader[0].ToString(), BddToDataTime(dataReader[1].ToString()), BddToDataTime(dataReader[2].ToString()), (bool)dataReader[4], dataReader[3].ToString()));
                }
                _conn.Close();
                return listIndispo;
            }
            return new ObservableCollection<AffichableEnListeBox>();
        }
        #endregion

        #region ChargeExceptDate
        public static ObservableCollection<AffichableEnListeBox> ChargeExceptDate(DateTime dateJour)
        {
            if (VerifConnection())
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "SELECT * FROM MACHINES_CALENDRIER WHERE DATE = @dateJour AND NOMACHINE != @nomachine"
                };
                cmd.Parameters.AddWithValue("@dateJour", dateJour);
                cmd.Parameters.AddWithValue("@nomachine", "");

                SqlDataReader dataReader = cmd.ExecuteReader();
                ObservableCollection<AffichableEnListeBox> listExcepts = new ObservableCollection<AffichableEnListeBox>();
                while (dataReader.Read())
                {
                    //Debug.WriteLine(dataReader[1].ToString());
                    listExcepts.Add(new ExceptionUVM(dataReader[0].ToString(), BddToDataTime(dataReader[1].ToString()), dataReader[2].ToString(), BddToHours(dataReader[3].ToString()), BddToHours(dataReader[4].ToString())));
                }
                _conn.Close();
                return new ObservableCollection<AffichableEnListeBox>(listExcepts.OrderBy(x => ((ExceptionUVM)x).NoMachine).ThenBy(y => ((ExceptionUVM)y).Date).ThenBy(z => ((ExceptionUVM)z).Poste));
            }
            return new ObservableCollection<AffichableEnListeBox>();
        }
        #endregion

        #region ChargerIndispos+ExceptsDate
        public static ObservableCollection<AffichableEnListeBox> ChargerIndisposExceptsDate(DateTime dateJour)
        {
            ObservableCollection<AffichableEnListeBox> res = ChargeIndispoDate(dateJour);
            ObservableCollection<AffichableEnListeBox> res2 = ChargeExceptDate(dateJour);
            foreach (AffichableEnListeBox elem in res2)
            {
                res.Add(elem);
            }
            return res;
        }
        #endregion

        #region Converter BDDTo
        private static DateTime BddToDataTime(string o)
        {
            int annee = 2017, mois = 11, jour = 2;

            jour = int.Parse(o.Substring(0, 2));
            mois = int.Parse(o.Substring(3, 2));
            annee = int.Parse(o.Substring(6, 4));

            return new DateTime(annee, mois, jour);
        }

        private static TimeSpan BddToHours(string o)
        {
            int heure = 1, minute = 1;
            if (o.Contains("."))
            {
                char x = '.';
                string[] res = o.Split(x);
                if (int.Parse(res[1]) >= 10)
                {
                    return new TimeSpan(int.Parse(res[0]), (int) ((int)int.Parse(res[1]) * 0.6), 0);
                }
                return new TimeSpan(int.Parse(res[0]), int.Parse(res[1])*60, 0);
            }
            else
            {
                return new TimeSpan(int.Parse(o), 0,0);
            }
        }
        #endregion

        #region Remplissage2025 Avec Semaine TYPE
        public static void SemaineType(DateTime date)
        {
            string equipe = "";

            float HD = 0;
            float HF = 0;

            _conn.Open();
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                for (int y = 1; y <= 2; y++)
                {
                    if (y == 1)
                    {
                        equipe = "WE1";
                        HD = 2;
                        HF = 14;
                    }
                    if (y == 2)
                    {
                        equipe = "WE2";
                        HD = 14;
                        HF = 2;
                    }

                    float duree = 0;
                    if (HF > HD)
                    {
                        duree = HF - HD;
                    }
                    else
                    {
                        duree = (24 - HD) + HF;
                    }

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = _conn,
                        CommandText =
                            "INSERT INTO MACHINES_CALENDRIER (NOMACHINE, DATE, EQUIPE, HEURE_DEB, HEURE_FIN, DUREE, JOUR, NOLIGNE) VALUES (@nomachine, @date, @equipe, @heure_deb, @heure_fin, @duree, @jour, @ligne)"
                    };
                    cmd.Parameters.AddWithValue("@nomachine", "");
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    cmd.Parameters.AddWithValue("@equipe", equipe);
                    cmd.Parameters.AddWithValue("@heure_deb", HD);
                    cmd.Parameters.AddWithValue("@heure_fin", HF);
                    cmd.Parameters.AddWithValue("@duree", duree);
                    cmd.Parameters.AddWithValue("@jour", date.DayOfWeek);
                    cmd.Parameters.AddWithValue("@ligne", y);
                    cmd.ExecuteNonQuery();
                }
                _conn.Close();
                return;
            }

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                for (int y = 1; y <= 2; y++)
                {
                    int jour = 0;
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        jour = 7;
                    }
                    else
                    {
                        jour = (int)date.DayOfWeek;
                    }

                    if (y == 1)
                    {
                        equipe = "WE1";
                        HD = (float)6.5;
                        HF = (float)18.5;
                    }
                    if (y == 2)
                    {
                        equipe = "WE2";
                        HD = (float)18.5;
                        HF = (float)6.5;
                    }

                    float duree = 0;
                    if (HF > HD)
                    {
                        duree = HF - HD;
                    }
                    else
                    {
                        duree = (24 - HD) + HF;
                    }

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = _conn,
                        CommandText =
                            "INSERT INTO MACHINES_CALENDRIER (NOMACHINE, DATE, EQUIPE, HEURE_DEB, HEURE_FIN, DUREE, JOUR, NOLIGNE) VALUES (@nomachine, @date, @equipe, @heure_deb, @heure_fin, @duree ,@jour, @ligne)"
                    };
                    cmd.Parameters.AddWithValue("@nomachine", "");
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    cmd.Parameters.AddWithValue("@equipe", equipe);
                    cmd.Parameters.AddWithValue("@heure_deb", HD);
                    cmd.Parameters.AddWithValue("@heure_fin", HF);
                    cmd.Parameters.AddWithValue("@duree", duree);
                    cmd.Parameters.AddWithValue("@jour", jour);
                    cmd.Parameters.AddWithValue("@ligne", y);
                    cmd.ExecuteNonQuery();
                }
                _conn.Close();
                return;
            }

            for (int x = 1; x <= 3; x++)
            {
                if (x == 1)
                {
                    equipe = "MAT";
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            HD = (float) 6.5 ;
                            HF = (float) 13;
                            break;
                        case DayOfWeek.Tuesday:
                            HD = (float) 5 ;
                            HF = (float) 13; 
                            break;
                        case DayOfWeek.Wednesday:
                            HD = (float) 5 ;
                            HF = (float) 13; 
                            break;
                        case DayOfWeek.Thursday:
                            HD = (float) 5 ;
                            HF = (float) 13; 
                            break;
                        case DayOfWeek.Friday:
                            HD = (float) 5 ;
                            HF = (float) 13; 
                            break;
                    }
                }
                if (x == 2)
                {
                    equipe = "SOI";
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            HD = (float) 13 ;
                            HF = (float) 21;
                            break;
                        case DayOfWeek.Tuesday:
                            HD = (float) 13 ;
                            HF = (float) 21; 
                            break;
                        case DayOfWeek.Wednesday:
                            HD = (float) 13 ;
                            HF = (float) 21; 
                            break;
                        case DayOfWeek.Thursday:
                            HD = (float) 13 ;
                            HF = (float) 21; 
                            break;
                        case DayOfWeek.Friday:
                            HD = (float) 13 ;
                            HF = (float) 19.5; 
                            break;
                    }
                }
                if (x == 3)
                {
                    equipe = "NUI";
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            HD = (float) 21 ;
                            HF = (float) 5;
                            break;
                        case DayOfWeek.Tuesday:
                            HD = (float) 21 ;
                            HF = (float) 5; 
                            break;
                        case DayOfWeek.Wednesday:
                            HD = (float) 21 ;
                            HF = (float) 5; 
                            break;
                        case DayOfWeek.Thursday:
                            HD = (float) 21 ;
                            HF = (float) 5; 
                            break;
                        case DayOfWeek.Friday:
                            HD = (float) 19.5 ;
                            HF = (float) 2; 
                            break;
                    }
                }

                float duree = 0;
                if (HF > HD)
                {
                    duree = HF - HD;
                }
                else
                {
                    duree = (24 - HD) + HF;
                }

                SqlCommand cmd = new SqlCommand
                {
                    Connection = _conn,
                    CommandText =
                        "INSERT INTO MACHINES_CALENDRIER (NOMACHINE, DATE, EQUIPE, HEURE_DEB, HEURE_FIN, DUREE, JOUR, NOLIGNE) VALUES (@nomachine, @date, @equipe, @heure_deb, @heure_fin, @duree, @jour, @ligne)"
                };
                cmd.Parameters.AddWithValue("@nomachine", "");
                cmd.Parameters.AddWithValue("@date", date.Date);
                cmd.Parameters.AddWithValue("@equipe", equipe);
                cmd.Parameters.AddWithValue("@heure_deb", HD);
                cmd.Parameters.AddWithValue("@heure_fin", HF);
                cmd.Parameters.AddWithValue("@duree", duree);
                cmd.Parameters.AddWithValue("@jour",date.DayOfWeek);
                cmd.Parameters.AddWithValue("@ligne", x);
                cmd.ExecuteNonQuery();
            }
            _conn.Close();


        }

        public static void TotalTest(DateTime dDebut, DateTime dFin)
        {
            TimeSpan ts = dFin - dDebut;

            SemaineType(dDebut);
            for (int nb = 1; nb<ts.Days;nb++)
            {
                SemaineType(dDebut.AddDays(nb));    
            }
            SemaineType(dFin);
            
        }
        #endregion

        public static void CleanTable()
        {
            if (VerifConnection())
            {
                _conn.Open();
                string sqlTrunc = "TRUNCATE TABLE MACHINES_CALENDRIER";
                SqlCommand cmd = new SqlCommand(sqlTrunc, _conn);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }


    }
}
