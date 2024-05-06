using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Form1 : Form
    {
        Notification f = new Notification();
        private void Form1_Load(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            button1.Enabled = false;
            richTextBox1.Enabled = false;
        }
        public static FSM<State,Event> fsm;
        public static DateTime date ;
       
        public static string text;
       
        public Form1()
        {
            InitializeComponent();
            
            fsm = new(State.OpenWindow);
            fsm.RegisterTrans(new Transition<State, Event>[]
            {
                new Transition<State,Event>
                {
                    FromState=State.OpenWindow,
                    ToState = State.ChooseDate,
                    Event=Event.Creation
                },
                new Transition<State,Event>
                {
                    FromState=State.ChooseDate,
                    ToState = State.DiscribeEvent,
                    Event=Event.DateChoosen
                },
                
                new Transition<State,Event>
                {
                    FromState=State.ChooseTime,
                    ToState = State.DiscribeEvent,
                    Event=Event.DateChoosen
                },
                new Transition<State,Event>
                {
                    FromState=State.DiscribeEvent,
                    ToState = State.WaitForEvent,
                    Event=Event.EndCreating
                },
                new Transition<State,Event>
                {
                    FromState=State.WaitForEvent,
                    ToState = State.Notify,
                    Event=Event.EventStarted
                },
                new Transition<State,Event>
                {
                    FromState=State.Notify,
                    ToState = State.PutOff,
                    Event=Event.EventIsPutOff
                },
                new Transition<State,Event>
                {
                    FromState=State.Notify,
                    ToState = State.CloseNotification,
                    Event=Event.WindowClosed
                },
                new Transition<State,Event>
                {
                    FromState=State.Notify,
                    ToState = State.OpenWindow,
                    Event=Event.CalendarOpened
                },
                new Transition<State,Event>
                {
                    FromState=State.PutOff,
                    ToState = State.Notify,
                    Event=Event.Notification
                },


            });

            
        }



        public enum State
        {
            OpenWindow,
            ChooseDate,
            ChooseTime,
            DiscribeEvent,
            WaitForEvent,
            Notify,
            CloseNotification,
            PutOff,

        }
        public enum Event
        {
            Creation,
            DateChoosen,
            TimeChoosen,
            DescriptionAdded,
            EndCreating,
            EventStarted,
            Notification,
            EventIsPutOff,
            WindowClosed,
            CalendarOpened,
            WaitingStart,
        }

        public class State <S> where S:Enum
        {
            public S Name { get; set; }
            public Action OnEnter;
            public Action OnUpdate;
            public Action OnExit;

        }

        public class Transition <S,E> where S :Enum
            where E:Enum
        {
            public S FromState { get; set; }
            public S ToState { get; set; }
            public E Event { get; set; }

            
        }

        public class FSM <S,E> where S : Enum
            where E : Enum
        {
            Dictionary<S, State<S>> states = new();
            List<Transition<S, E>> transition;
            State<S> currentState = null;
            
            public S State
            {
                get { return currentState.Name; }
                set { SetState(value); }
            }

            bool SetState(S StateName)
            {
                if (!states.ContainsKey(StateName))
                    return false;
                currentState.OnExit?.Invoke();
                currentState = states[StateName];
                currentState.OnEnter?.Invoke();
                return true;
            }

            public FSM (S initialState)
            {
                foreach(S item in Enum.GetValues(typeof(S)))
                {
                    State<S> state = new() { Name=item};
                    states.Add(state.Name, state);
                }
                currentState = GetState(initialState);
            }
            public void RegisterTrans(Transition<S, E>[] trans) 
            {
                transition = new(trans);
            }

            public void Tick()
            {
                currentState.OnUpdate?.Invoke();
            }



            State<S> GetState(S st)
            {
                if (!states.ContainsKey(st))
                    return null;
                return states[st];
            }

            public void OnEvent(E Event)
            {
                var res = transition.Where(
                    e => (e.FromState == null) ||
                    (e.FromState.Equals(currentState.Name))
                    && (e.Event.Equals(Event)));
                if (res.Any()) 
                    SetState(res.First().ToState);
            }

            public State<S> this [S StateName]
            {
                get
                {
                    if (!states.ContainsKey(StateName))
                        return null;
                    return states[StateName];
                }
            }


        }



        bool IsNotified = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            fsm.Tick();
            
            label1.Text = fsm.State.ToString();
            
            if (!IsNotified && IsChoosen==true )
            {
                if (date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day == DateTime.Now.Day)
                {
                    if (date.Hour == DateTime.Now.Hour && date.Minute == DateTime.Now.Minute)
                    {

                        Notification newForm = new Notification();
                        newForm.Show();
                        fsm.OnEvent(Event.EventStarted);
                        timer2.Stop();
                        IsNotified = true;
                    }
                }
            }
            if (Notification.IsPutOff == true)
            {
                fsm.OnEvent(Form1.Event.Notification);
                Thread.Sleep(5000);
                f.Show();
                fsm.OnEvent(Form1.Event.Notification);

                Notification.IsPutOff = false;

            }
        }

        bool IsChoosen=false;
       
        private void button1_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            
            fsm.OnEvent(Event.EndCreating);
            IsChoosen = true;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            fsm.OnEvent(Event.Creation);
            richTextBox1.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            fsm.OnEvent(Event.DateChoosen);
            text = richTextBox1.Text;
            button1.Enabled = true;
        }

       

        
    }
}
