using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSTSCLib;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace RDP
{
   

    public partial class Form1 : Form
    {
        IPStatus status_global = IPStatus.TimedOut;
        IPStatus status_local = IPStatus.TimedOut;
        Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        //Переменные для MySQL
        string global_ping = @"ya.ru"; //Для пинга на ВЦ
        //string global_ping = @"127.0.0.1"; //Для пинга на ВЦ
        /////////////////////////////////////////////////////////////////////
        string ServMySQL = @"10.10.101.101"; //Для пинга на ВЦ
        //string ServMySQL = @"127.0.0.1"; //Для пинга дома
        /////////////////////////////////////////////////////////////////////
        string connStr = "server=" + "10.10.101.101" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + ";";//Для подключения на ВЦ
        //string connStr = "server=" + "127.0.0.1" + ";user=" + "root" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + ";";//Для подключения Дома
        /////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Производится подключение...");


            ///////////////////////////////////////////////////////////////
            this.AcceptButton = cnct_rdp;
            ///////////////////////////////////////////////////////////////
            {
                address.Text = null;
                login.Text = null;
            }



        try
            {
                            ///////////////////////////////////////////////////////////////
                            Ping ping_global = new Ping();
                            PingReply reply_global = ping_global.Send(global_ping);//Проверка интернета
                            //PingReply reply_global = ping_global.Send(ServMySQL); //Проверка интернета ДОМА.
                            status_global = reply_global.Status;
                            ///////////////////////////////////////////////////////////////
                            Ping ping_local = new Ping();
                            PingReply reply_local = ping_local.Send(ServMySQL, 10);
                            status_local = reply_local.Status;
                            ///////////////////////////////////////////////////////////////
                            /////
                if (status_local == IPStatus.Success)
                    {
                    MessageBox.Show("База доступна. Ты в локалке. Загружаем списки для Групп");
                    ///////////////////////////////////////////////////////////////   Подключение по MySql
                    //{
                    //    MySqlConnection conn_sp_grp = new MySqlConnection(connStr);
                    //    conn_sp_grp.Open();

                    //    MySqlCommand GRP = new MySqlCommand("SELECT FAM FROM dpo.users_dpo where CHK = 1;", conn_sp_grp);
                    //    MySqlDataReader comb_grp = GRP.ExecuteReader();

                    //    while (comb_grp.Read())
                    //    {

                    //        string table1 = comb_grp.GetString(0);
                    //        spisok_box.Items.Add(table1);
                    //    }
                    //    comb_grp.Close();
                    //}
                    {
                        MySqlConnection conn_sp_grp = new MySqlConnection(connStr);
                        conn_sp_grp.Open();

                        MySqlCommand GRP = new MySqlCommand("SELECT GRP FROM dpo.users_dpo where CHK = '1' group by GRP;", conn_sp_grp);
                        MySqlDataReader comb_grp = GRP.ExecuteReader();

                        while (comb_grp.Read())
                        {

                            string table1 = comb_grp.GetString(0);
                            ComboGRP.Items.Add(table1);
                        }
                        comb_grp.Close();
                    }
                }
                else if (status_global == IPStatus.Success)
                    {
                                    MessageBox.Show("Хоть инет есть. Интернет. Запуск ВПН");
                                    ///////ньюконфиг
                    {
                                    string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Мои документы"
                                    string rkiu_folder = MyDoc + "\\RKIU"; ///// Папка "Мои документы\RKIU\"
                                    string PBK_File = rkiu_folder + @"\connection.pbk"; ///// Файл "Мои документы\RKIU\connection.pbk"
                                    string BAT_File_Connect = rkiu_folder + @"\connection.bat"; ///// Файл "Мои документы\RKIU\connection.bat"
                                    //this.Text = (rkiu_folder);

                                    {///// Если не нашел Файл "Мои документы\RKIU\connection.pbk" то создать Папку "Мои документы\RKIU\" и Пустой файл "Мои документы\RKIU\connection.pbk" с записью нижеизложенного. (полный конфиг)
                            if

                                        (File.Exists(PBK_File) == false)
                                            Directory.CreateDirectory(rkiu_folder);
                                        FileStream PBK_Text = new FileStream(PBK_File, FileMode.Create);
                                        StreamWriter PBK_Writer = new StreamWriter(PBK_Text);


                                        {///// Полный конфиг PBK файла.
                                            PBK_Writer.WriteLine("[RKIU]");
                                            PBK_Writer.WriteLine("Encoding=1");
                                            PBK_Writer.WriteLine("PBVersion=1");
                                            PBK_Writer.WriteLine("Type=2");
                                            PBK_Writer.WriteLine("AutoLogon=0");
                                            PBK_Writer.WriteLine("UseRasCredentials=1");
                                            PBK_Writer.WriteLine("LowDateTime=-1406685632");
                                            PBK_Writer.WriteLine("HighDateTime=30552741");
                                            PBK_Writer.WriteLine("DialParamsUID=167606281");
                                            PBK_Writer.WriteLine("Guid=FBC982CFFD24754B9EE04E331B9FF727");
                                            PBK_Writer.WriteLine("VpnStrategy=2");
                                            PBK_Writer.WriteLine("ExcludedProtocols=0");
                                            PBK_Writer.WriteLine("LcpExtensions=1");
                                            PBK_Writer.WriteLine("DataEncryption=256");
                                            PBK_Writer.WriteLine("SwCompression=0");
                                            PBK_Writer.WriteLine("NegotiateMultilinkAlways=0");
                                            PBK_Writer.WriteLine("SkipDoubleDialDialog=0");
                                            PBK_Writer.WriteLine("DialMode=0");
                                            PBK_Writer.WriteLine("OverridePref=15");
                                            PBK_Writer.WriteLine("RedialAttempts=3");
                                            PBK_Writer.WriteLine("RedialSeconds=60");
                                            PBK_Writer.WriteLine("IdleDisconnectSeconds=0");
                                            PBK_Writer.WriteLine("RedialOnLinkFailure=1");
                                            PBK_Writer.WriteLine("CallbackMode=0");
                                            PBK_Writer.WriteLine("CustomDialDll=");
                                            PBK_Writer.WriteLine("CustomDialFunc=");
                                            PBK_Writer.WriteLine("CustomRasDialDll=");
                                            PBK_Writer.WriteLine("ForceSecureCompartment=0");
                                            PBK_Writer.WriteLine("DisableIKENameEkuCheck=0");
                                            PBK_Writer.WriteLine("AuthenticateServer=0");
                                            PBK_Writer.WriteLine("ShareMsFilePrint=1");
                                            PBK_Writer.WriteLine("BindMsNetClient=1");
                                            PBK_Writer.WriteLine("SharedPhoneNumbers=0");
                                            PBK_Writer.WriteLine("GlobalDeviceSettings=0");
                                            PBK_Writer.WriteLine("PrerequisiteEntry=");
                                            PBK_Writer.WriteLine("PrerequisitePbk=");
                                            PBK_Writer.WriteLine("PreferredPort=VPN3-0");
                                            PBK_Writer.WriteLine("PreferredDevice=WAN Miniport (PPTP)");
                                            PBK_Writer.WriteLine("PreferredBps=0");
                                            PBK_Writer.WriteLine("PreferredHwFlow=1");
                                            PBK_Writer.WriteLine("PreferredProtocol=1");
                                            PBK_Writer.WriteLine("PreferredCompression=1");
                                            PBK_Writer.WriteLine("PreferredSpeaker=1");
                                            PBK_Writer.WriteLine("PreferredMdmProtocol=0");
                                            PBK_Writer.WriteLine("PreviewUserPw=1");
                                            PBK_Writer.WriteLine("PreviewDomain=1");
                                            PBK_Writer.WriteLine("PreviewPhoneNumber=0");
                                            PBK_Writer.WriteLine("ShowDialingProgress=1");
                                            PBK_Writer.WriteLine("ShowMonitorIconInTaskBar=1");
                                            PBK_Writer.WriteLine("CustomAuthKey=0");
                                            PBK_Writer.WriteLine("AuthRestrictions=544");
                                            PBK_Writer.WriteLine("IpPrioritizeRemote=1");
                                            PBK_Writer.WriteLine("IpInterfaceMetric=0");
                                            PBK_Writer.WriteLine("IpHeaderCompression=0");
                                            PBK_Writer.WriteLine("IpAddress=0.0.0.0");
                                            PBK_Writer.WriteLine("IpDnsAddress=0.0.0.0");
                                            PBK_Writer.WriteLine("IpDns2Address=0.0.0.0");
                                            PBK_Writer.WriteLine("IpWinsAddress=0.0.0.0");
                                            PBK_Writer.WriteLine("IpWins2Address=0.0.0.0");
                                            PBK_Writer.WriteLine("IpAssign=1");
                                            PBK_Writer.WriteLine("IpNameAssign=1");
                                            PBK_Writer.WriteLine("IpDnsFlags=0");
                                            PBK_Writer.WriteLine("IpNBTFlags=1");
                                            PBK_Writer.WriteLine("TcpWindowSize=0");
                                            PBK_Writer.WriteLine("UseFlags=2");
                                            PBK_Writer.WriteLine("IpSecFlags=0");
                                            PBK_Writer.WriteLine("IpDnsSuffix=");
                                            PBK_Writer.WriteLine("Ipv6Assign=1");
                                            PBK_Writer.WriteLine("Ipv6Address=::");
                                            PBK_Writer.WriteLine("Ipv6PrefixLength=0");
                                            PBK_Writer.WriteLine("Ipv6PrioritizeRemote=1");
                                            PBK_Writer.WriteLine("Ipv6InterfaceMetric=0");
                                            PBK_Writer.WriteLine("TESIpv6NameAssign=1T");
                                            PBK_Writer.WriteLine("Ipv6DnsAddress=::");
                                            PBK_Writer.WriteLine("Ipv6Dns2Address=::");
                                            PBK_Writer.WriteLine("Ipv6Prefix=0000000000000000");
                                            PBK_Writer.WriteLine("Ipv6InterfaceId=0000000000000000");
                                            PBK_Writer.WriteLine("DisableClassBasedDefaultRoute=0");
                                            PBK_Writer.WriteLine("DisableMobility=0");
                                            PBK_Writer.WriteLine("NetworkOutageTime=1800");
                                            PBK_Writer.WriteLine("ProvisionType=0");
                                            PBK_Writer.WriteLine("PreSharedKey=");

                                            PBK_Writer.WriteLine("NETCOMPONENTS=");
                                            PBK_Writer.WriteLine("ms_msclient=1");
                                            PBK_Writer.WriteLine("ms_server=1");

                                            PBK_Writer.WriteLine("MEDIA=rastapi");
                                            PBK_Writer.WriteLine("Port=VPN3-0");
                                            PBK_Writer.WriteLine("Device=WAN Miniport (PPTP)");

                                            PBK_Writer.WriteLine("DEVICE=vpn");
                                            PBK_Writer.WriteLine("PhoneNumber=109.195.230.222");
                                            PBK_Writer.WriteLine("AreaCode=");
                                            PBK_Writer.WriteLine("CountryCode=0");
                                            PBK_Writer.WriteLine("CountryID=0");
                                            PBK_Writer.WriteLine("UseDialingRules=0");
                                            PBK_Writer.WriteLine("Comment=");
                                            PBK_Writer.WriteLine("FriendlyName=");
                                            PBK_Writer.WriteLine("LastSelectedPhone=0");
                                            PBK_Writer.WriteLine("PromoteAlternates=0");
                                            PBK_Writer.WriteLine("TryNextAlternateOnFail=1");


                                        }




                                        {///// Закрыть поток. Иначе не сохранит.
                                            PBK_Writer.Close();
                                        }
                                    }
                            
                            if

                                          (File.Exists(BAT_File_Connect) == false);
                                        FileStream BAT_Text = new FileStream(BAT_File_Connect, FileMode.Create);
                                        StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                                        //BAT_Writer.WriteLine("@echo off");
                                        //BAT_Writer.Write("start /min ");
                                        BAT_Writer.Write(@"rasdial ""RKIU"" ");
                                        BAT_Writer.Write("vpn ");
                                        BAT_Writer.Write("rkiuvpn ");
                                        BAT_Writer.Write("/phonebook:");
                                        BAT_Writer.Write(@"""");
                                        BAT_Writer.Write(PBK_File);
                                        BAT_Writer.Write(@"""");
                                        BAT_Writer.Close();

                            

                            
                                        cnct.Enabled = false;
                                        dcnct.Enabled = true;
                                        ProcessStartInfo Connect_Process = new ProcessStartInfo(BAT_File_Connect);
                                        // Process Connect_Process = new Process(); ///старый коннект
                                        Connect_Process.WindowStyle = ProcessWindowStyle.Hidden;
                                        Connect_Process.RedirectStandardOutput = true;
                                        Connect_Process.UseShellExecute = false;
                                        Connect_Process.CreateNoWindow = true;
                                        //запуск процесса
                                        Process New_Connect_Process = Process.Start(Connect_Process);
                                        //получить ответ
                                        StreamReader str_incom = New_Connect_Process.StandardOutput;
                                        //выводим результат
                                        Console.WriteLine(str_incom.ReadToEnd());
                                        //закрыть процесс
                                        New_Connect_Process.WaitForExit();
                                        Console.Read();



                            
                            }
                                    ///////////////////////////////////////////////////////////////   Подключение по MySql после подключения vpn
                                    Ping ping = new Ping();
                                    PingReply pingReply = ping.Send(ServMySQL, 10000);
                                    Console.WriteLine(pingReply.RoundtripTime); //время ответа
                                    Console.WriteLine(pingReply.Status);        //статус
                                                                                //////////пытается, но у него не получается, просто занимает время чтобы поймать catch
                    try
                    {//////////////////////////////////////////////// Мой первый костыль костылей, который работает.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            MySqlConnection conn_sp = new MySqlConnection(connStr);
                            conn_sp.Open();
                            
                            //прерывание. ошибка
                            //MySqlCommand FAM = new MySqlCommand("SELECT FAM FROM dpo.users_dpo;", conn_sp);
                            //MySqlDataReader comb = FAM.ExecuteReader();

                            //while (comb.Read())
                            //{
                            //    string table1 = comb.GetString(0);
                            //    spisok_box.Items.Add(table1);
                            //}
                            //comb.Close();
                            //  MessageBox.Show("Работает по исключению");
                        }

                        else 
                        {
                            MessageBox.Show("Ошибка подключеня к серверу РГКИУ", "Все очень плохо. В заголовок", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }

                    }
                    catch
                    {
                        MySqlConnection conn_sp = new MySqlConnection(connStr);
                        conn_sp.Open();

                        MySqlCommand FAM = new MySqlCommand("SELECT FAM FROM dpo.users_dpo where CHK = 1;", conn_sp);
                        MySqlDataReader comb = FAM.ExecuteReader();

                        while (comb.Read())
                        {
                            string table1 = comb.GetString(0);
                            spisok_box.Items.Add(table1);
                        }
                        comb.Close();
                    }

                                ///////////////////////////////////////////////////////////////   Подключение по MySql после подключения vpn

                    }

                }

                        catch (Exception Ex) 
                        {
                            MessageBox.Show("Ошибка подключения " + address.Text + "\nОшибка:  " + Ex.Message, "Все очень плохо." , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }

            ///////////////////////////////////////////////////////////////


        }

      

        public Form1()
        {
            InitializeComponent();
            this.Text = Application.CompanyName;
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            ///////ньюконфиг2
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string rkiu_folder = MyDoc + "\\RKIU";
            string BAT_File_Disconnect = rkiu_folder + @"\disconnect.bat";
            {
                if

                (File.Exists(BAT_File_Disconnect) == false) ;
                FileStream BAT_Text = new FileStream(BAT_File_Disconnect, FileMode.Create);
                StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                //BAT_Writer.WriteLine("@echo off");
                //BAT_Writer.Write("start /min ");
                BAT_Writer.Write("rasdial/d");
                BAT_Writer.Close();

            }
            cnct.Enabled = true;
            dcnct.Enabled = false;
            ProcessStartInfo Disconnect_Process = new ProcessStartInfo(BAT_File_Disconnect);
            Disconnect_Process.WindowStyle = ProcessWindowStyle.Hidden;
            Disconnect_Process.RedirectStandardOutput = true;
            Disconnect_Process.UseShellExecute = false;
            Disconnect_Process.CreateNoWindow = true;
            //запуск процесса
            Process New_Disconnect_Process = Process.Start(Disconnect_Process);
            //получить ответ
            StreamReader str_incom = New_Disconnect_Process.StandardOutput;
            //выводим результат
            Console.WriteLine(str_incom.ReadToEnd());
            //закрыть процесс
            New_Disconnect_Process.WaitForExit();
            Console.Read();
            ///////ньюконфиг_конец
            MessageBox.Show("Досвидули");
        }

        private void cnct_rdp_Click(object sender, EventArgs e)
        {

            //  String server_rdp = "10.10.9.52";
            //  String username_rdp = "boss";
            //   String password_rdp = "newsign147";


            {
                    {
                        MySqlConnection conn = new MySqlConnection(connStr);
                        conn.Open();

                        MySqlCommand PVM = new MySqlCommand("SELECT PVM FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + " and CHK = 1;", conn);
                        MySqlDataReader rd = PVM.ExecuteReader();


                        while (rd.Read())
                        {
                            string table = rd.GetString(0);
                            ///  string table2 = log.GetString(0);

                            address.Text = table;
                            ///  label4.Text = table2;



                            // string table1 = rd1.GetString(0);
                            // label2.Text = table1;
                            //comboBox2.Items.Add(table);
                        }
                        rd.Close();
                        {
                            MySqlConnection conn2 = new MySqlConnection(connStr);
                            conn2.Open();
                            MySqlCommand LOGIN = new MySqlCommand("SELECT LOGIN FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + " and CHK = 1;", conn);
                            MySqlDataReader log = LOGIN.ExecuteReader();
                            while (log.Read())
                            {

                                string table2 = log.GetString(0);


                                login.Text = table2;


                            }
                            log.Close();
                        }

                    }

                    try
                    {


                        rdp.Visible = true;
                        rdp.Server = address.Text;
                        rdp.Domain = "COLLEGE";
                        rdp.UserName = login.Text;
                        IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                        secured.ClearTextPassword = textBox2.Text;
                        rdp.Connect();
                        /////
                        cnct_rdp.Visible = false;
                        dcnct_rdp.Visible = true;
                        //cnct_rdp.Enabled = false;
                        //dcnct_rdp.Enabled = true;
                        /////
                        this.Width = 768;
                        this.Height = 650;
                        address.Text = null;
                        login.Text = null;
                    }


                    catch
                    {
                    rdp.Visible = false;
                    MessageBox.Show("Ошибка подключения к удаленному рабочему столу " + address.Text + "\nОшибка: Неверный пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                }

               

            }
        }

        private void dcnct_rdp_Click(object sender, EventArgs e)
        {
            try
            {          
                // Check if connected before disconnecting
                {
                    if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();
                    this.Width = 768;
                    this.Height = 75;
                    address.Text = null;
                    login.Text = null;
                    /////
                    cnct_rdp.Visible = true;
                    dcnct_rdp.Visible = false;
                    /////
                    //cnct_rdp.Enabled = true;
                    //dcnct_rdp.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                rdp.Visible = false;
                MessageBox.Show("Ошибка отключения", "Ошибка отключения от удаленного рабочего стола " + address.Text + " Ошибка:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void cnct_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////ньюконфиг
            {
                string MyDocs = Application.CommonAppDataPath; //Может понадобится
                string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Мои документы"
                string rkiu_folder = MyDoc + "\\RKIU"; ///// Папка "Мои документы\RKIU\"
                string PBK_File = rkiu_folder + @"\connection.pbk"; ///// Файл "Мои документы\RKIU\connection.pbk"
                string BAT_File_Connect = rkiu_folder + @"\connection.bat"; ///// Файл "Мои документы\RKIU\connection.bat"
                this.Text = (rkiu_folder);

                {///// Если не нашел Файл "Мои документы\RKIU\connection.pbk" то создать Папку "Мои документы\RKIU\" и Пустой файл "Мои документы\RKIU\connection.pbk" с записью нижеизложенного. (полный конфиг)
                    if

                    (File.Exists(PBK_File) == false)
                        Directory.CreateDirectory(rkiu_folder);
                    FileStream PBK_Text = new FileStream(PBK_File, FileMode.Create);
                    StreamWriter PBK_Writer = new StreamWriter(PBK_Text);


                    {///// Полный конфиг PBK файла.
                        PBK_Writer.WriteLine("[RKIU]");
                        PBK_Writer.WriteLine("Encoding=1");
                        PBK_Writer.WriteLine("PBVersion=1");
                        PBK_Writer.WriteLine("Type=2");
                        PBK_Writer.WriteLine("AutoLogon=0");
                        PBK_Writer.WriteLine("UseRasCredentials=1");
                        PBK_Writer.WriteLine("LowDateTime=-1406685632");
                        PBK_Writer.WriteLine("HighDateTime=30552741");
                        PBK_Writer.WriteLine("DialParamsUID=167606281");
                        PBK_Writer.WriteLine("Guid=FBC982CFFD24754B9EE04E331B9FF727");
                        PBK_Writer.WriteLine("VpnStrategy=2");
                        PBK_Writer.WriteLine("ExcludedProtocols=0");
                        PBK_Writer.WriteLine("LcpExtensions=1");
                        PBK_Writer.WriteLine("DataEncryption=256");
                        PBK_Writer.WriteLine("SwCompression=0");
                        PBK_Writer.WriteLine("NegotiateMultilinkAlways=0");
                        PBK_Writer.WriteLine("SkipDoubleDialDialog=0");
                        PBK_Writer.WriteLine("DialMode=0");
                        PBK_Writer.WriteLine("OverridePref=15");
                        PBK_Writer.WriteLine("RedialAttempts=3");
                        PBK_Writer.WriteLine("RedialSeconds=60");
                        PBK_Writer.WriteLine("IdleDisconnectSeconds=0");
                        PBK_Writer.WriteLine("RedialOnLinkFailure=1");
                        PBK_Writer.WriteLine("CallbackMode=0");
                        PBK_Writer.WriteLine("CustomDialDll=");
                        PBK_Writer.WriteLine("CustomDialFunc=");
                        PBK_Writer.WriteLine("CustomRasDialDll=");
                        PBK_Writer.WriteLine("ForceSecureCompartment=0");
                        PBK_Writer.WriteLine("DisableIKENameEkuCheck=0");
                        PBK_Writer.WriteLine("AuthenticateServer=0");
                        PBK_Writer.WriteLine("ShareMsFilePrint=1");
                        PBK_Writer.WriteLine("BindMsNetClient=1");
                        PBK_Writer.WriteLine("SharedPhoneNumbers=0");
                        PBK_Writer.WriteLine("GlobalDeviceSettings=0");
                        PBK_Writer.WriteLine("PrerequisiteEntry=");
                        PBK_Writer.WriteLine("PrerequisitePbk=");
                        PBK_Writer.WriteLine("PreferredPort=VPN3-0");
                        PBK_Writer.WriteLine("PreferredDevice=WAN Miniport (PPTP)");
                        PBK_Writer.WriteLine("PreferredBps=0");
                        PBK_Writer.WriteLine("PreferredHwFlow=1");
                        PBK_Writer.WriteLine("PreferredProtocol=1");
                        PBK_Writer.WriteLine("PreferredCompression=1");
                        PBK_Writer.WriteLine("PreferredSpeaker=1");
                        PBK_Writer.WriteLine("PreferredMdmProtocol=0");
                        PBK_Writer.WriteLine("PreviewUserPw=1");
                        PBK_Writer.WriteLine("PreviewDomain=1");
                        PBK_Writer.WriteLine("PreviewPhoneNumber=0");
                        PBK_Writer.WriteLine("ShowDialingProgress=1");
                        PBK_Writer.WriteLine("ShowMonitorIconInTaskBar=1");
                        PBK_Writer.WriteLine("CustomAuthKey=0");
                        PBK_Writer.WriteLine("AuthRestrictions=544");
                        PBK_Writer.WriteLine("IpPrioritizeRemote=1");
                        PBK_Writer.WriteLine("IpInterfaceMetric=0");
                        PBK_Writer.WriteLine("IpHeaderCompression=0");
                        PBK_Writer.WriteLine("IpAddress=0.0.0.0");
                        PBK_Writer.WriteLine("IpDnsAddress=0.0.0.0");
                        PBK_Writer.WriteLine("IpDns2Address=0.0.0.0");
                        PBK_Writer.WriteLine("IpWinsAddress=0.0.0.0");
                        PBK_Writer.WriteLine("IpWins2Address=0.0.0.0");
                        PBK_Writer.WriteLine("IpAssign=1");
                        PBK_Writer.WriteLine("IpNameAssign=1");
                        PBK_Writer.WriteLine("IpDnsFlags=0");
                        PBK_Writer.WriteLine("IpNBTFlags=1");
                        PBK_Writer.WriteLine("TcpWindowSize=0");
                        PBK_Writer.WriteLine("UseFlags=2");
                        PBK_Writer.WriteLine("IpSecFlags=0");
                        PBK_Writer.WriteLine("IpDnsSuffix=");
                        PBK_Writer.WriteLine("Ipv6Assign=1");
                        PBK_Writer.WriteLine("Ipv6Address=::");
                        PBK_Writer.WriteLine("Ipv6PrefixLength=0");
                        PBK_Writer.WriteLine("Ipv6PrioritizeRemote=1");
                        PBK_Writer.WriteLine("Ipv6InterfaceMetric=0");
                        PBK_Writer.WriteLine("TESIpv6NameAssign=1T");
                        PBK_Writer.WriteLine("Ipv6DnsAddress=::");
                        PBK_Writer.WriteLine("Ipv6Dns2Address=::");
                        PBK_Writer.WriteLine("Ipv6Prefix=0000000000000000");
                        PBK_Writer.WriteLine("Ipv6InterfaceId=0000000000000000");
                        PBK_Writer.WriteLine("DisableClassBasedDefaultRoute=0");
                        PBK_Writer.WriteLine("DisableMobility=0");
                        PBK_Writer.WriteLine("NetworkOutageTime=1800");
                        PBK_Writer.WriteLine("ProvisionType=0");
                        PBK_Writer.WriteLine("PreSharedKey=");

                        PBK_Writer.WriteLine("NETCOMPONENTS=");
                        PBK_Writer.WriteLine("ms_msclient=1");
                        PBK_Writer.WriteLine("ms_server=1");

                        PBK_Writer.WriteLine("MEDIA=rastapi");
                        PBK_Writer.WriteLine("Port=VPN3-0");
                        PBK_Writer.WriteLine("Device=WAN Miniport (PPTP)");

                        PBK_Writer.WriteLine("DEVICE=vpn");
                        PBK_Writer.WriteLine("PhoneNumber=109.195.230.222");
                        PBK_Writer.WriteLine("AreaCode=");
                        PBK_Writer.WriteLine("CountryCode=0");
                        PBK_Writer.WriteLine("CountryID=0");
                        PBK_Writer.WriteLine("UseDialingRules=0");
                        PBK_Writer.WriteLine("Comment=");
                        PBK_Writer.WriteLine("FriendlyName=");
                        PBK_Writer.WriteLine("LastSelectedPhone=0");
                        PBK_Writer.WriteLine("PromoteAlternates=0");
                        PBK_Writer.WriteLine("TryNextAlternateOnFail=1");


                    }




                    {///// Закрыть поток. Иначе не сохранит.
                        PBK_Writer.Close();
                    }
                }
                {
                    if

                      (File.Exists(BAT_File_Connect) == false) ;
                    FileStream BAT_Text = new FileStream(BAT_File_Connect, FileMode.Create);
                    StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                    //BAT_Writer.WriteLine("@echo off");
                    //BAT_Writer.Write("start /min ");
                    BAT_Writer.Write(@"rasdial ""RKIU"" ");
                    BAT_Writer.Write("vpn ");
                    BAT_Writer.Write("rkiuvpn ");
                    BAT_Writer.Write("/phonebook:");
                    BAT_Writer.Write(@"""");
                    BAT_Writer.Write(PBK_File);
                    BAT_Writer.Write(@"""");
                    BAT_Writer.Close();

                }

                {
                    cnct.Enabled = false;
                    dcnct.Enabled = true;
                    ProcessStartInfo Connect_Process = new ProcessStartInfo(BAT_File_Connect);
                    // Process Connect_Process = new Process(); ///старый коннект
                    Connect_Process.WindowStyle = ProcessWindowStyle.Hidden;
                    Connect_Process.RedirectStandardOutput = true;
                    Connect_Process.UseShellExecute = false;
                    Connect_Process.CreateNoWindow = true;
                    //запуск процесса
                    Process New_Connect_Process = Process.Start(Connect_Process);
                    //получить ответ
                    StreamReader str_incom = New_Connect_Process.StandardOutput;
                    //выводим результат
                    Console.WriteLine(str_incom.ReadToEnd());
                    //закрыть процесс
                    New_Connect_Process.WaitForExit();
                    Console.Read();
                }
            }

            //////        ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/C ping ya.ru");        
            //////// скрываем окно запущенного процесса
            //////psiOpt.WindowStyle = ProcessWindowStyle.Hidden;       
            //////psiOpt.RedirectStandardOutput = true;        
            //////psiOpt.UseShellExecute = false;      
            //////psiOpt.CreateNoWindow = true;       
            //////// запускаем процесс
            //////Process procCommand = Process.Start(psiOpt);    
            //////// получаем ответ запущенного процесса
            //////StreamReader srIncoming = procCommand.StandardOutput;      
            //////// выводим результат
            //////Console.WriteLine(srIncoming.ReadToEnd());        
            //////// закрываем процесс
            //////procCommand.WaitForExit(); 
            //////Console.Read();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////букап
            ////////string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Мои документы"
            ////////string rkiu_folder = MyDoc + "\\RKIU"; ///// Папка "Мои документы\RKIU\"
            ////////string PBK_File = rkiu_folder + @"\connection.pbk"; ///// Файл "Мои документы\RKIU\connection.pbk"
            ////////string BAT_File_Connect = rkiu_folder + @"\connection.bat"; ///// Файл "Мои документы\RKIU\connection.bat"
            ////////this.Text = (rkiu_folder);

            ////////{///// Если не нашел Файл "Мои документы\RKIU\connection.pbk" то создать Папку "Мои документы\RKIU\" и Пустой файл "Мои документы\RKIU\connection.pbk" с записью нижеизложенного. (полный конфиг)
            ////////    if

            ////////    (File.Exists(PBK_File) == false)
            ////////        Directory.CreateDirectory(rkiu_folder);
            ////////    FileStream PBK_Text = new FileStream(PBK_File, FileMode.Create);
            ////////    StreamWriter PBK_Writer = new StreamWriter(PBK_Text);


            ////////    {///// Краткий конфиг PBK файла. Очень долгий. Каждый раз генерится полный конфиг из краткого.
            ////////        //PBK_Writer.WriteLine("[RKIU]");
            ////////        //PBK_Writer.WriteLine("MEDIA=rastapi");
            ////////        //PBK_Writer.WriteLine("Port=VPN2-0");
            ////////        //PBK_Writer.WriteLine("Device=WAN Miniport (IKEv2)");
            ////////        //PBK_Writer.WriteLine("DEVICE=vpn");
            ////////        //PBK_Writer.WriteLine("PhoneNumber=109.195.230.222");
            ////////    }


            ////////    {///// Полный конфиг PBK файла.
            ////////        PBK_Writer.WriteLine("[RKIU]");
            ////////        PBK_Writer.WriteLine("Encoding=1");
            ////////        PBK_Writer.WriteLine("PBVersion=1");
            ////////        PBK_Writer.WriteLine("Type=2");
            ////////        PBK_Writer.WriteLine("AutoLogon=0");
            ////////        PBK_Writer.WriteLine("UseRasCredentials=1");
            ////////        PBK_Writer.WriteLine("LowDateTime=-1406685632");
            ////////        PBK_Writer.WriteLine("HighDateTime=30552741");
            ////////        PBK_Writer.WriteLine("DialParamsUID=167606281");
            ////////        PBK_Writer.WriteLine("Guid=FBC982CFFD24754B9EE04E331B9FF727");
            ////////        PBK_Writer.WriteLine("VpnStrategy=2");
            ////////        PBK_Writer.WriteLine("ExcludedProtocols=0");
            ////////        PBK_Writer.WriteLine("LcpExtensions=1");
            ////////        PBK_Writer.WriteLine("DataEncryption=256");
            ////////        PBK_Writer.WriteLine("SwCompression=0");
            ////////        PBK_Writer.WriteLine("NegotiateMultilinkAlways=0");
            ////////        PBK_Writer.WriteLine("SkipDoubleDialDialog=0");
            ////////        PBK_Writer.WriteLine("DialMode=0");
            ////////        PBK_Writer.WriteLine("OverridePref=15");
            ////////        PBK_Writer.WriteLine("RedialAttempts=3");
            ////////        PBK_Writer.WriteLine("RedialSeconds=60");
            ////////        PBK_Writer.WriteLine("IdleDisconnectSeconds=0");
            ////////        PBK_Writer.WriteLine("RedialOnLinkFailure=1");
            ////////        PBK_Writer.WriteLine("CallbackMode=0");
            ////////        PBK_Writer.WriteLine("CustomDialDll=");
            ////////        PBK_Writer.WriteLine("CustomDialFunc=");
            ////////        PBK_Writer.WriteLine("CustomRasDialDll=");
            ////////        PBK_Writer.WriteLine("ForceSecureCompartment=0");
            ////////        PBK_Writer.WriteLine("DisableIKENameEkuCheck=0");
            ////////        PBK_Writer.WriteLine("AuthenticateServer=0");
            ////////        PBK_Writer.WriteLine("ShareMsFilePrint=1");
            ////////        PBK_Writer.WriteLine("BindMsNetClient=1");
            ////////        PBK_Writer.WriteLine("SharedPhoneNumbers=0");
            ////////        PBK_Writer.WriteLine("GlobalDeviceSettings=0");
            ////////        PBK_Writer.WriteLine("PrerequisiteEntry=");
            ////////        PBK_Writer.WriteLine("PrerequisitePbk=");
            ////////        PBK_Writer.WriteLine("PreferredPort=VPN3-0");
            ////////        PBK_Writer.WriteLine("PreferredDevice=WAN Miniport (PPTP)");
            ////////        PBK_Writer.WriteLine("PreferredBps=0");
            ////////        PBK_Writer.WriteLine("PreferredHwFlow=1");
            ////////        PBK_Writer.WriteLine("PreferredProtocol=1");
            ////////        PBK_Writer.WriteLine("PreferredCompression=1");
            ////////        PBK_Writer.WriteLine("PreferredSpeaker=1");
            ////////        PBK_Writer.WriteLine("PreferredMdmProtocol=0");
            ////////        PBK_Writer.WriteLine("PreviewUserPw=1");
            ////////        PBK_Writer.WriteLine("PreviewDomain=1");
            ////////        PBK_Writer.WriteLine("PreviewPhoneNumber=0");
            ////////        PBK_Writer.WriteLine("ShowDialingProgress=1");
            ////////        PBK_Writer.WriteLine("ShowMonitorIconInTaskBar=1");
            ////////        PBK_Writer.WriteLine("CustomAuthKey=0");
            ////////        PBK_Writer.WriteLine("AuthRestrictions=544");
            ////////        PBK_Writer.WriteLine("IpPrioritizeRemote=1");
            ////////        PBK_Writer.WriteLine("IpInterfaceMetric=0");
            ////////        PBK_Writer.WriteLine("IpHeaderCompression=0");
            ////////        PBK_Writer.WriteLine("IpAddress=0.0.0.0");
            ////////        PBK_Writer.WriteLine("IpDnsAddress=0.0.0.0");
            ////////        PBK_Writer.WriteLine("IpDns2Address=0.0.0.0");
            ////////        PBK_Writer.WriteLine("IpWinsAddress=0.0.0.0");
            ////////        PBK_Writer.WriteLine("IpWins2Address=0.0.0.0");
            ////////        PBK_Writer.WriteLine("IpAssign=1");
            ////////        PBK_Writer.WriteLine("IpNameAssign=1");
            ////////        PBK_Writer.WriteLine("IpDnsFlags=0");
            ////////        PBK_Writer.WriteLine("IpNBTFlags=1");
            ////////        PBK_Writer.WriteLine("TcpWindowSize=0");
            ////////        PBK_Writer.WriteLine("UseFlags=2");
            ////////        PBK_Writer.WriteLine("IpSecFlags=0");
            ////////        PBK_Writer.WriteLine("IpDnsSuffix=");
            ////////        PBK_Writer.WriteLine("Ipv6Assign=1");
            ////////        PBK_Writer.WriteLine("Ipv6Address=::");
            ////////        PBK_Writer.WriteLine("Ipv6PrefixLength=0");
            ////////        PBK_Writer.WriteLine("Ipv6PrioritizeRemote=1");
            ////////        PBK_Writer.WriteLine("Ipv6InterfaceMetric=0");
            ////////        PBK_Writer.WriteLine("TESIpv6NameAssign=1T");
            ////////        PBK_Writer.WriteLine("Ipv6DnsAddress=::");
            ////////        PBK_Writer.WriteLine("Ipv6Dns2Address=::");
            ////////        PBK_Writer.WriteLine("Ipv6Prefix=0000000000000000");
            ////////        PBK_Writer.WriteLine("Ipv6InterfaceId=0000000000000000");
            ////////        PBK_Writer.WriteLine("DisableClassBasedDefaultRoute=0");
            ////////        PBK_Writer.WriteLine("DisableMobility=0");
            ////////        PBK_Writer.WriteLine("NetworkOutageTime=1800");
            ////////        PBK_Writer.WriteLine("ProvisionType=0");
            ////////        PBK_Writer.WriteLine("PreSharedKey=");

            ////////        PBK_Writer.WriteLine("NETCOMPONENTS=");
            ////////        PBK_Writer.WriteLine("ms_msclient=1");
            ////////        PBK_Writer.WriteLine("ms_server=1");

            ////////        PBK_Writer.WriteLine("MEDIA=rastapi");
            ////////        PBK_Writer.WriteLine("Port=VPN3-0");
            ////////        PBK_Writer.WriteLine("Device=WAN Miniport (PPTP)");

            ////////        PBK_Writer.WriteLine("DEVICE=vpn");
            ////////        PBK_Writer.WriteLine("PhoneNumber=109.195.230.222");
            ////////        PBK_Writer.WriteLine("AreaCode=");
            ////////        PBK_Writer.WriteLine("CountryCode=0");
            ////////        PBK_Writer.WriteLine("CountryID=0");
            ////////        PBK_Writer.WriteLine("UseDialingRules=0");
            ////////        PBK_Writer.WriteLine("Comment=");
            ////////        PBK_Writer.WriteLine("FriendlyName=");
            ////////        PBK_Writer.WriteLine("LastSelectedPhone=0");
            ////////        PBK_Writer.WriteLine("PromoteAlternates=0");
            ////////        PBK_Writer.WriteLine("TryNextAlternateOnFail=1");


            ////////    }
            ////////    {///// Закрыть поток. Иначе не сохранит.
            ////////        PBK_Writer.Close();
            ////////    }

            ////////}

            ////////{
            ////////    if

            ////////      (File.Exists(BAT_File_Connect) == false) ;
            ////////    FileStream BAT_Text = new FileStream(BAT_File_Connect, FileMode.Create);
            ////////    StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
            ////////    BAT_Writer.WriteLine("@echo off");
            ////////    BAT_Writer.Write("start /min ");
            ////////    BAT_Writer.Write(@"rasdial ""RKIU"" ");
            ////////    BAT_Writer.Write("vpn ");
            ////////    BAT_Writer.Write("rkiuvpn ");
            ////////    BAT_Writer.Write("/phonebook:");
            ////////    BAT_Writer.Write(@"""");
            ////////    BAT_Writer.Write(PBK_File);
            ////////    BAT_Writer.Write(@"""");
            ////////    BAT_Writer.Close();

            ////////}

            ////////Process Connect_Process = new Process();
            ////////Connect_Process = new Process();
            ////////Connect_Process.StartInfo.FileName = BAT_File_Connect;
            ////////Connect_Process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            ////////Connect_Process.Start();
            ////////Connect_Process.WaitForExit();
            ////////cnct.Enabled = false;
            ////////dcnct.Enabled = true;



            //////////Process.Start(BAT_File);

            ////////// File.WriteAllText(file, mytext);
            //////////using (StreamWriter outputFile = new StreamWriter(vpndirpath + "\\RKIU" + @"\connection.pbk", true))
            //////////{
            //////////    outputFile.WriteLine("[RKIU-DPO]");
            //////////    outputFile.WriteLine("MEDIA=rastapi");
            //////////    outputFile.WriteLine("Port=VPN2-0");
            //////////    outputFile.WriteLine("Device=WAN Miniport (IKEv2)");
            //////////    outputFile.WriteLine("DEVICE=vpn");
            //////////    outputFile.WriteLine("PhoneNumber=109.195.230.222");
            //////////}
            //////////using (StreamWriter outputFile = new StreamWriter(vpndirpath + "\\RKIU" + @"\connection.bat", true))
            //////////{
            //////////       // File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\vpnconnector" & "\connection.pbk"));
            //////////    //outputFile.WriteLine("[RKIU-DPO]");


            //////////}
        }

        private void dcnct_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////ньюконфиг2
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string rkiu_folder = MyDoc + "\\RKIU";
            string BAT_File_Disconnect = rkiu_folder + @"\disconnect.bat";
            {
                if

                (File.Exists(BAT_File_Disconnect) == false) ;
                FileStream BAT_Text = new FileStream(BAT_File_Disconnect, FileMode.Create);
                StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                BAT_Writer.WriteLine("@echo off");
                //BAT_Writer.Write("start /min ");
                BAT_Writer.Write("rasdial/d");
                BAT_Writer.Close();

            }
            cnct.Enabled = true;
            dcnct.Enabled = false;
            ProcessStartInfo Disconnect_Process = new ProcessStartInfo(BAT_File_Disconnect);
            Disconnect_Process.WindowStyle = ProcessWindowStyle.Hidden;
            Disconnect_Process.RedirectStandardOutput = true;
            Disconnect_Process.UseShellExecute = false;
            Disconnect_Process.CreateNoWindow = true;
            //запуск процесса
            Process New_Disconnect_Process = Process.Start(Disconnect_Process);
            //получить ответ
            StreamReader str_incom = New_Disconnect_Process.StandardOutput;
            //выводим результат
            Console.WriteLine(str_incom.ReadToEnd());
            //закрыть процесс
            New_Disconnect_Process.WaitForExit();
            Console.Read();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////букап
            //////Process Disconnect_Process = new Process();
            //////Disconnect_Process = new Process();
            //////Disconnect_Process.StartInfo.FileName = BAT_File_Disconnect;
            //////Disconnect_Process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //////Disconnect_Process.Start();
            //////Disconnect_Process.WaitForExit();
            //////cnct.Enabled = true;
            //////dcnct.Enabled = false;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Width = 823;
            this.Height = 780;
        }

        private void txtUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private AxMSTSCLib.AxMsRdpClient5 rdpClient; //для full_screen
        private void full_Click(object sender, EventArgs e)
        {
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlCommand PVM = new MySqlCommand("SELECT PVM FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + " and CHK = 1;", conn);
                MySqlDataReader rd = PVM.ExecuteReader();


                while (rd.Read())
                {
                    string table = rd.GetString(0);
                    ///  string table2 = log.GetString(0);

                    address.Text = table;
                    ///  label4.Text = table2;



                    // string table1 = rd1.GetString(0);
                    // label2.Text = table1;
                    //comboBox2.Items.Add(table);
                }
                rd.Close();
                {
                    MySqlConnection conn2 = new MySqlConnection(connStr);
                    conn2.Open();
                    MySqlCommand LOGIN = new MySqlCommand("SELECT LOGIN FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + " and CHK = 1;", conn);
                    MySqlDataReader log = LOGIN.ExecuteReader();
                    while (log.Read())
                    {

                        string table2 = log.GetString(0);


                        login.Text = table2;


                    }
                    log.Close();
                }

            }


            try
            {
                rdpClient = new AxMSTSCLib.AxMsRdpClient5();
                ((ISupportInitialize)rdpClient).BeginInit();
                // rdpClient.Enabled = true;
                //rdpClient.Location = new System.Drawing.Point(0, 0);
                // rdpClient.Name = "MsRdpClient";
                rdpClient.Size = new System.Drawing.Size(screenSize.Size.Width, screenSize.Size.Height);
                rdpClient.TabIndex = 1;
                rdpClient.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                Controls.Add(rdpClient); ((ISupportInitialize)rdpClient).EndInit();
                


                //String username = "boss";
                //String password = "newsign147";
                rdpClient.Server = address.Text;
                rdpClient.UserName = login.Text;
                rdpClient.AdvancedSettings2.ClearTextPassword = textBox2.Text;
                rdpClient.Domain = "COLLEGE";
                rdpClient.FullScreen = true;

                ////rdpClient.AdvancedSettings2.RedirectDrives = false;
                ////rdpClient.AdvancedSettings2.RedirectPrinters = false;
                ////rdpClient.AdvancedSettings2.RedirectPorts = false;
                ////rdpClient.AdvancedSettings2.RedirectSmartCards = false;
                ////rdpClient.AdvancedSettings6.RedirectClipboard = false;
                ////rdpClient.AdvancedSettings6.MinutesToIdleTimeout = 1;
                //////////////////////////////////////////////////////////////////////////////////
                //rdpClient.AdvancedSettings2.ContainerHandledFullScreen = 1;
                

                rdpClient.AdvancedSettings4.ConnectionBarShowRestoreButton = false;
                rdpClient.AdvancedSettings4.ConnectionBarShowMinimizeButton = false;
                rdpClient.AdvancedSettings4.PinConnectionBar = false;
                //rdpClient.AdvancedSettings4.DisplayConnectionBar = false; 


                //////////////////////////////////////////////////////////////////////////////////
                // rdpClient.Size = new System.Drawing.Size(screenSize.Size.Width, screenSize.Size.Height);


                rdpClient.Connect();
                rdpClient.Visible = false;                // ГИПЕР КОСТЫЛЬ, надеюсь временно
                //rdp.Visible = false;                    //????
                ///////////////////////////
                this.Width = 768;
                this.Height = 75;
                address.Text = null;
                login.Text = null;
                /////
                cnct_rdp.Visible = true;
                dcnct_rdp.Visible = false;
                /////

                                            //скрыть белоеполотно!!!
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к удаленному рабочему столу " + address.Text + "\nОшибка: Неверный пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //{
            //    MySqlConnection conn = new MySqlConnection(connStr);
            //    conn.Open();

            //    MySqlCommand PVM = new MySqlCommand("SELECT PVM FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + ";", conn);
            //    MySqlDataReader rd = PVM.ExecuteReader();


            //    while (rd.Read())
            //    {
            //        string table = rd.GetString(0);
            //        ///  string table2 = log.GetString(0);

            //        address.Text = table;
            //        ///  label4.Text = table2;



            //        // string table1 = rd1.GetString(0);
            //        // label2.Text = table1;
            //        //comboBox2.Items.Add(table);
            //    }
            //    rd.Close();
            //    {
            //        MySqlConnection conn2 = new MySqlConnection(connStr);
            //        conn2.Open();
            //        MySqlCommand LOGIN = new MySqlCommand("SELECT LOGIN FROM dpo.users_dpo where FAM=" + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS=" + "'" + textBox2.Text + "'" + ";", conn);
            //        MySqlDataReader log = LOGIN.ExecuteReader();
            //        while (log.Read())
            //        {

            //            string table2 = log.GetString(0);


            //            login.Text = table2;


            //        }
            //        log.Close();
            //    }

            //}


            //фулл скрин
            ////////////////////////////////////////////////////////////////////////
            //////////////////String username = "boss";
            //////////////////    String password = "newsign147";
            //////////////////    String server = "10.10.9.52";
            //////////////////    rdpClient.Server = server;
            //////////////////    rdpClient.UserName = username;
            //////////////////    rdpClient.AdvancedSettings2.ClearTextPassword = password;
            //////////////////    rdpClient.Domain = "college";
            //////////////////    rdpClient.FullScreen = true;



            //////////////////    rdpClient.AdvancedSettings2.RedirectDrives = false;
            //////////////////    rdpClient.AdvancedSettings2.RedirectPrinters = false;
            //////////////////    rdpClient.AdvancedSettings2.RedirectPorts = false;
            //////////////////    rdpClient.AdvancedSettings2.RedirectSmartCards = false;
            //////////////////    rdpClient.AdvancedSettings6.RedirectClipboard = false;
            //////////////////    rdpClient.AdvancedSettings6.MinutesToIdleTimeout = 1;
            //////////////////    //  rdpClient.Size = new System.Drawing.Size(1000, 1000);

            //////////////////    rdpClient.Connect();

            ////////////////////////////////////////////////////////////////////////
            //rdp.Server = address.Text;
            //rdp.Domain = "COLLEGE";
            //rdp.UserName = login.Text;
            //IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
            //secured.ClearTextPassword = textBox2.Text;
            //rdp.Connect();
            ///////
            //cnct_rdp.Enabled = false;
            //dcnct_rdp.Enabled = true;
            ///////
            //this.Width = 778;
            //this.Height = 660;


        }

        private void ComboGRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGRP.SelectedIndex > -1)
            {
                spisok_box.Items.Clear();
                {
                    MySqlConnection conn_sp = new MySqlConnection(connStr);
                    conn_sp.Open();
                    MySqlCommand FAM = new MySqlCommand("SELECT FAM FROM dpo.users_dpo where GRP = " + "'" + ComboGRP.SelectedItem + "'" + ";", conn_sp);
                    MySqlDataReader comb = FAM.ExecuteReader();
                    while (comb.Read())
                    {

                        string table1 = comb.GetString(0);
                        spisok_box.Items.Add(table1);

                    }
                    comb.Close();
                }
                spisok_box.Enabled = true;          
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void spisok_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }
    }
}