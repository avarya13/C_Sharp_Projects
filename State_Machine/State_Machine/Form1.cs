using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace State_Machine
{
    public partial class Form1 : Form
    {
        public static FSM<State, Event> fsm;
        public Form1()
        {
            InitializeComponent();

            fsm = new(State.StartMaking);

            fsm.RegisterTrans(new Transition<State, Event>[]
            {
                new Transition<State,Event>
                {
                    FromState=State.StartMaking,
                    ToState = State.ChooseAmericano,
                    Event=Event.AmericanoChoosen
                },
                new Transition<State,Event>
                {
                    FromState=State.StartMaking,
                    ToState = State.ChooseCappuccino,
                    Event=Event.CappuccinoChoosen
                },
                new Transition<State,Event>
                {
                    FromState=State.ChooseCappuccino,
                    ToState = State.GrindGrains,
                    Event=Event.EnoughGrains
                },
                new Transition<State,Event>
                {
                    FromState=State.ChooseAmericano,
                    ToState = State.GrindGrains,
                    Event=Event.EnoughGrains
                },

                new Transition<State,Event>
                {
                    FromState=State.GrindGrains,
                    ToState = State.StopMaking,
                    Event=Event.LackOfWater
                },
                new Transition<State,Event>
                {
                    FromState=State.PassWater,
                    ToState = State.StopMaking,
                    Event=Event.LackOfMilk
                },
                new Transition<State,Event>
                {
                    FromState=State.GrindGrains,
                    ToState = State.HeatWater,
                    Event=Event.EnoughWater
                },
                new Transition<State,Event>
                {
                    FromState=State.HeatWater,
                    ToState = State.PassWater,
                    Event=Event.WaterHeated
                },
                new Transition<State,Event>
                {
                    FromState=State.PassWater,
                    ToState = State.Complete,
                    Event=Event.EndOfMaking
                },
                 new Transition<State,Event>
                {
                    FromState=State.PassWater,
                    ToState = State.PassSteamThroughMilk,
                    Event=Event.EnoughMilk
                },
                new Transition<State,Event>
                {
                    FromState=State.PassSteamThroughMilk,
                    ToState = State.Complete,
                    Event=Event.EndOfMaking
                },
                new Transition<State,Event>
                {
                    FromState=State.Complete,
                    ToState = State.Pour,
                    Event=Event.ReadyForPouring
                },
                new Transition<State,Event>
                {
                    FromState=State.Pour,
                    ToState = State.End,
                    Event=Event.Done
                },
                new Transition<State,Event>
                {
                    FromState=State.End,
                    ToState = State.StartMaking,
                    Event=Event.StartAgain
                },

             });
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            label14.Text = portion.ToString();
            label15.Text = water.ToString();
            label16.Text = milk.ToString();
            
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            IsAmericano =true;
            fsm.OnEvent(Event.AmericanoChoosen);
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            fsm.OnEvent(Event.CappuccinoChoosen);
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = portion.ToString();
            label15.Text = water.ToString();
            label16.Text = milk.ToString();
            label7.Text = fsm.State.ToString();
        }

        public enum State
        {
            ChooseAmericano,
            ChooseCappuccino,
            StartMaking,
            StopMaking,
            GrindGrains,
            HeatWater,
            PassWater,
            PassSteamThroughMilk,
            End,
            Pour,
            Complete

        }
        public enum Event
        {
            
            CappuccinoChoosen,
            AmericanoChoosen,
            LackOfGrains,
            LackOfMilk,
            LackOfWater,
            EnoughGrains,
            EnoughWater,
            EnoughMilk,
            WaterHeated,
            EndOfMaking,
           
            ReadyForPouring,
            Done,
            StartAgain
            
        }

        public class State<S> where S : Enum
        {
            public S Name { get; set; }
            public Action OnEnter;
            public Action OnUpdate;
            public Action OnExit;

        }

        public class Transition<S, E> where S : Enum
            where E : Enum
        {
            public S FromState { get; set; }
            public S ToState { get; set; }
            public E Event { get; set; }


        }

        public class FSM<S, E> where S : Enum
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

            public FSM(S initialState)
            {
                foreach (S item in Enum.GetValues(typeof(S)))
                {
                    State<S> state = new() { Name = item };
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

            public State<S> this[S StateName]
            {
                get
                {
                    if (!states.ContainsKey(StateName))
                        return null;
                    return states[StateName];
                }
            }


        }
        int portion = 2;
        int water = 200;
        int milk = 100;
        bool EnoughIngredients=true;
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (portion > 0)
            {
                textBox1.Text = "перемалывание зерен";
                fsm.OnEvent(Event.EnoughGrains);
                portion--;
            }
            else
            {
                textBox1.Text = "недостаточно зерен";
                fsm.OnEvent(Event.LackOfGrains);
                EnoughIngredients = false;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (EnoughIngredients)
            {
                if (water >= 100)
                {
                    textBox2.Text = "нагревание воды в бойлере";
                    fsm.OnEvent(Event.EnoughWater);
                    water -= 100;
                }
                else
                {
                    textBox2.Text = "недостаточно воды";
                    fsm.OnEvent(Event.LackOfWater);
                    EnoughIngredients = false;
                }
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (EnoughIngredients)
            {
                textBox3.Text = "пропускание воды через кофе под давлением";
                fsm.OnEvent(Event.WaterHeated);
            }
        }



        bool IsAmericano=false;
        

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "завершить приготовление";
            fsm.OnEvent(Event.EndOfMaking);
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            if (EnoughIngredients)
            {
                textBox6.Text = "налить в стакан";
                fsm.OnEvent(Event.ReadyForPouring);
            }
        }
        

        private void textBox7_Click(object sender, EventArgs e)
        {
            if (EnoughIngredients)
            {
                textBox7.Text = "готово к выдаче";
                fsm.OnEvent(Event.Done);
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (EnoughIngredients)
            {
                if (!IsAmericano)
                {
                    if (milk >= 50)
                    {
                        textBox4.Text = "вспенивание и добавление в кофе молока";
                        fsm.OnEvent(Event.EnoughMilk);
                        milk -= 50;
                    }
                    else
                    {
                        textBox1.Text = "недостаточно молока";
                        fsm.OnEvent(Event.LackOfMilk);
                        EnoughIngredients = false;
                    }
                }
                else textBox4.Text = "---";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fsm.OnEvent(Event.StartAgain);
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }
    }
}
