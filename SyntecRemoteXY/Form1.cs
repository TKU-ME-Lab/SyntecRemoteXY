using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

using Syntec.Remote;

public enum BitType
{
    I,
    R,
    C
}

public enum BitMode
{
    Read,
    Write
}

namespace SyntecRemoteXY
{
    public partial class Form1 : Form
    {
        private SyntecRemoteCNC CNC = null;
        private ConnectionState state = ConnectionState.Closed;
        private BitType m_bittype = BitType.R;
        private BitMode m_bitmode = BitMode.Read;

        public Form1()
        {
            InitializeComponent();
        }

        private void m_buttonConnect_Click(object sender, EventArgs e)
        {
            String host = m_textBoxIP.Text;
            if(state == ConnectionState.Closed)
            {                                               //Conncet Syntec controller, host: controler IP address
                CNC = new SyntecRemoteCNC(host, 10000);     //連接Syntec控制器 host: 控制器IP位址 ,port: 10000，EX:SyntecRemoteCNC("192.168.0.10",10000)
                if (!CNC.isConnected())     //檢查連線狀態，連上回傳1，反之回傳0    Check connect status
                {
                    m_listBoxLog_ShowLog("Can not connect:" + host);
                    m_buttonConnect.BackColor = SystemColors.Control;
                    m_labelStatusVal.Text = "NOTREADY";
                    m_timerReadPos.Stop();
                    m_timerstatus.Stop();
                    CNC.Close();
                    m_textBoxIP.ReadOnly = false;
                    state = ConnectionState.Closed;
                }
                else
                {
                    m_buttonConnect.BackColor = Color.Lime;
                    m_listBoxLog_ShowLog("Connect:" + host);
                    m_textBoxIP.ReadOnly = true;

                    m_timerReadPos.Enabled = true;
                    m_timerReadPos.Start();

                    m_timerstatus.Enabled = true;
                    m_timerstatus.Start();

                    m_timerAlarm.Enabled = true;

                    state = ConnectionState.Connecting;
                }
            }
            else
            {
                m_timerAlarm.Stop();
                m_buttonConnect.BackColor = SystemColors.Control;
                m_labelStatusVal.Text = "NOTREADY";
                m_timerReadPos.Stop();
                m_timerstatus.Stop();
                CNC.Close();
                m_textBoxIP.ReadOnly = false;
                state = ConnectionState.Closed;
            }
        }

        private void m_listBoxLog_ShowLog(string msg)
        {
            m_listBoxLog.Items.Add(msg);
        }

        private void m_comboBoxBitMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mode = m_comboBoxBitMode.SelectedIndex;

            switch (mode)
            {
                case 0:
                    m_bitmode = BitMode.Read;
                    m_textBoxBitValue.ReadOnly = true;
                    m_listBoxLog_ShowLog("Mode Change to Read");
                    break;
                case 1:
                    m_bitmode = BitMode.Write;
                    m_textBoxBitValue.ReadOnly = false;
                    m_listBoxLog_ShowLog("Mode Change to Write");
                    break;
                default:
                    break;
            }
        }

        private void m_comboBoxBitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = m_comboBoxBitType.SelectedIndex;

            switch (type)
            {                               
                case 0:                                    
                    m_bittype = BitType.I;                 
                    m_listBoxLog_ShowLog("Bit Type Change to I");
                    break;                                 
                case 1:                                    
                    m_bittype = BitType.R;                 
                    m_listBoxLog_ShowLog("Bit Type Change to R");
                    break;
                case 2:
                    m_bittype = BitType.C;
                    m_listBoxLog_ShowLog("Bit Type Change to C");
                    break;
                default:
                    break;
            }
        }

        private void m_timerReadPos_Tick(object sender, EventArgs e)
        {
            if (m_bitmode == BitMode.Read)
            {
                int Rstart = 26;
                int Rend = 27;

                int[] data;
                short result = CNC.READ_plc_register(Rstart, Rend, out data);       //取得PLC Register 位址資料，Rstart:位址起始值, Rend:位址終止值, data:Plc資料(int)
                                                                                    //Get the PLC data from Register address, Rstart: start address, Rend: end address, data: PLC data(int)

                if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)   //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                {                                                                   //Check error message, NormalTermination: Work is finish, return 0
                    m_listBoxLog_ShowLog("Fail Read Position");
                }
                else
                {
                    m_labelXVal.Text = String.Concat((float)data[0] / 1000);
                    m_labelYVal.Text = String.Concat((float)data[1] / 1000);
                }
            }
        }

        private void m_textBoxBitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (state == ConnectionState.Connecting && m_bitmode == BitMode.Read)
                {
                    int no = int.Parse(m_textBoxBitNo.Text);
                    short result;

                    switch (m_bittype)
                    {
                        case BitType.I:
                            byte[] data;        
                            result = CNC.READ_plc_ibit(no,no, out data);  //取得PLC I Bit位址資料，no(第一個):位址起始值, no(第二個):位址終止值, data:Plc資料(byte)
                                                                          //Get the PLC data from I Bit address, Rstart: start address, Rend: end address, data: PLC data(int)

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)   //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                            {                                                                   //Check error message, NormalTermination: Work is finish, return 0
                                m_listBoxLog_ShowLog("Fail Read I Bit");
                            }
                            else
                            {
                                m_textBoxBitValue.Text = String.Concat(data[0]);
                                m_listBoxLog_ShowLog("Read I" + no + ": " + data[0]);
                            }
                            break;
                        case BitType.R:
                            int[] Rdata;
                            result = CNC.READ_plc_register(no,no, out Rdata);   //取得PLC Register 位址資料，Rstart:位址起始值, Rend:位址終止值, data:Plc資料(int)

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)   //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                            {
                                m_listBoxLog_ShowLog("Fail Read Position");
                            }
                            else
                            {
                                m_textBoxBitValue.Text = String.Concat(Rdata[0]);
                                m_listBoxLog_ShowLog("Read R" + no + ": " + Rdata[0]);
                            }
                            break;
                        case BitType.C:
                            result = CNC.READ_plc_cbit(no, no, out data);   //取得PLC C Bit位址資料，no(第一個):位址起始值, no(第二個):位址終止值, data:Plc資料(byte)

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)   //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                            {
                                m_listBoxLog_ShowLog("Fail Read C Bit");
                            }
                            else
                            {
                                m_textBoxBitValue.Text = String.Concat(data[0]);
                                m_listBoxLog_ShowLog("Read C" + no + ": " + data[0]);
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
                else
                {
                    m_listBoxLog_ShowLog("Please Connect first");
                }
            }
        }
        System.DateTime[] OldAlmtime = { };
        private void m_timerstatus_Tick(object sender, EventArgs e)
        {
            if (state == ConnectionState.Connecting)
            {
                string Mainprog;    
                string Curprog;     
                int CurSeq;         
                string Mode;      
                string Status;    //控制器狀態，有兩種狀態 Ready 和 NotReady    controller status, Ready or NotReady
                string Alarm;     
                bool IsAlarm;       //判斷是否有警報   
                string EMG;       
                string[] AlmMsg;    //取得目前發生的警報訊息
                System.DateTime[] Almtime;  //取得目前發生的警報時間
                short result;

                result = CNC.READ_status(out Mainprog, out Curprog, out CurSeq,     //讀取狀態資訊，完成作業，回傳0
                                        out Mode, out Status, out Alarm, out EMG);
                if(result == (short)SyntecRemoteCNC.ErrorCode.NormalTermination)    //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                {
                    m_labelStatusVal.Text = Status;
                }

                result = CNC.READ_alm_current(out IsAlarm, out AlmMsg, out Almtime);    //目前發生的警報，完成作業，回傳0
                if (result == (short)SyntecRemoteCNC.ErrorCode.NormalTermination)   //確認錯誤訊息 NormalTermination:完成作業，未發生錯誤，回傳值0
                {
                    if (IsAlarm)    //判斷是否有警報
                    {
                        m_timerAlarm.Start();
                        if (String.Concat(OldAlmtime) != String.Concat(Almtime))
                        {
                            m_listBoxLog_ShowLog(String.Concat(AlmMsg));
                        }
                        OldAlmtime = Almtime;
                    }
                    else
                    {
                        m_timerAlarm.Stop();
                        m_buttonConnect.BackColor = Color.Lime;
                    }
                }
            }
        }

        private void m_buttonStop_Click(object sender, EventArgs e)
        {
            if(state == ConnectionState.Connecting)
            {
                byte[] data = {0};
                /*********寫入PLC C BIT位址資料*************/
                //37(第一個):位址起始值, 37(第二個):位址終止值, data:Plc資料(byte)
                //C37:外界對CNC發出RESET指令，1: 觸發C37，0: 重設C37, C37定義根據'PLC元件說明手冊'
                data[0] = 1;
                CNC.WRITE_plc_cbit(37, 37, data);   
                data[0] = 0;
                CNC.WRITE_plc_cbit(37, 37, data);
                /**********寫入PLC C BIT位址資料************/
                m_listBoxLog_ShowLog("STOP!!!!!!!!!!!!!!!");
            }
            else
            {
                m_listBoxLog_ShowLog("Please Connect first");
            }
        }

        private void m_textBoxBitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (m_bitmode == BitMode.Write && state == ConnectionState.Connecting)
                {
                    int no = int.Parse(m_textBoxBitNo.Text);
                    int[] Rdata = { 0 };
                    byte[] data = { 0 };
                    
                    if (m_bittype == BitType.R)
                    {
                        Rdata[0] = int.Parse(m_textBoxBitValue.Text);
                    }
                    else
                    {
                        data[0] = byte.Parse(m_textBoxBitValue.Text);
                    }
                    
                    switch (m_bittype)
                    {
                        case BitType.I:
                            CNC.WRITE_plc_ibit(no, no, data);   //寫入PLC I BIT位址資料，no(第一個):位址起始值, no(第二個):位址終止值, data:Plc資料(byte)
                            m_listBoxLog_ShowLog("Write I" + no + ": " + data[0]);
                            break;
                        case BitType.R:
                            
                            CNC.WRITE_plc_register(no, no, Rdata);  //寫入PLC Register BIT位址資料，no(第一個):位址起始值, no(第二個):位址終止值, Rdata:Plc資料(int)
                            m_listBoxLog_ShowLog("Write R" + no + ": " + Rdata[0]);
                            break;
                        case BitType.C:
                            CNC.WRITE_plc_cbit(no, no, data);   //寫入PLC C BIT位址資料，no(第一個):位址起始值, no(第二個):位址終止值, data:Plc資料(byte)
                            m_listBoxLog_ShowLog("Write C" + no + ": " + data[0]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void m_timerAlarm_Tick(object sender, EventArgs e)
        {
            if(m_buttonConnect.BackColor == SystemColors.Control)
            m_buttonConnect.BackColor = Color.Red;
            else
            m_buttonConnect.BackColor = SystemColors.Control;
        }
    }
}
