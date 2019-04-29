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

        static NetworkStream m_NetStream;

        public Form1()
        {
            InitializeComponent();
        }

        private void m_buttonStatus_Click(object sender, EventArgs e)
        {
        }

        private void m_buttonConnect_Click(object sender, EventArgs e)
        {
            String host = m_textBoxIP.Text;
            if(state == ConnectionState.Closed)
            {
                CNC = new SyntecRemoteCNC(host, 10000);
                if (!CNC.isConnected())
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
                short result = CNC.READ_plc_register(Rstart, Rend, out data);

                if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)
                {
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
                            result = CNC.READ_plc_ibit(no, no, out data);

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)
                            {
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
                            result = CNC.READ_plc_register(no, no, out Rdata);

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)
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
                            result = CNC.READ_plc_cbit(no, no, out data);

                            if (result != (short)SyntecRemoteCNC.ErrorCode.NormalTermination)
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
        string[] OldAlmMsg = {""};
        private void m_timerstatus_Tick(object sender, EventArgs e)
        {
            if (state == ConnectionState.Connecting)
            {
                string Mainprog;    //主程式
                string Curprog;     //現在在執行的程式
                int CurSeq;         //用不到
                bool IsAlarm;       //確認警告訊號
                string m_Mode;      //控制器模式 EX: 手動、自動執行....
                string m_Status;    //控制器狀態
                string m_Alarm;     //警報
                string m_EMG;       //緊急停止
                string[] AlmMsg;    //警告訊息

                System.DateTime[] Almtime;

                CNC.READ_status(out Mainprog, out Curprog, out CurSeq,
                                                out m_Mode, out m_Status, out m_Alarm, out m_EMG);
                CNC.READ_alm_current(out IsAlarm, out AlmMsg, out Almtime);

                m_labelStatusVal.Text = m_Status;
                if (IsAlarm)
                {
                    m_timerAlarm.Start();
                    if (String.Concat(OldAlmMsg) != String.Concat(AlmMsg))
                    {
                        m_listBoxLog_ShowLog(String.Concat(AlmMsg));
                    }
                    OldAlmMsg = AlmMsg;
                }
                else
                {
                    m_timerAlarm.Stop();
                    m_buttonConnect.BackColor = Color.Lime;
                }
            }
        }

        private void m_buttonStop_Click(object sender, EventArgs e)
        {
            if(state == ConnectionState.Connecting)
            {
                byte[] data = {0};
                data[0] = 1;
                CNC.WRITE_plc_cbit(37, 37, data);
                data[0] = 0;
                CNC.WRITE_plc_cbit(37, 37, data);
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
                            CNC.WRITE_plc_ibit(no, no, data);
                            m_listBoxLog_ShowLog("Write I" + no + ": " + data[0]);
                            break;
                        case BitType.R:
                            
                            CNC.WRITE_plc_register(no, no, Rdata);
                            m_listBoxLog_ShowLog("Write R" + no + ": " + Rdata[0]);
                            break;
                        case BitType.C:
                            CNC.WRITE_plc_cbit(no, no, data);
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
