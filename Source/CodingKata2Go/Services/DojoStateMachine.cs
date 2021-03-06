﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingKata2Go.DataModel;
using GalaSoft.MvvmLight;

namespace CodingKata2Go.Services
{
    public class DojoStateMachine : ObservableObject
    {
        private readonly List<DojoState> m_states;
        private DojoState m_currentState;

        public DojoStateMachine()
        {
            m_states = new List<DojoState>();
        }

        public void Add(DojoState state)
        {
            m_states.Add(state);
        }

        public void AddAndActivate(DojoState state)
        {
            m_states.Add(state);
            GoTo(state);
        }

        public IEnumerable<DojoState> States
        {
            get { return m_states; }
        }

        public void GoTo(DojoState state)
        {
            if (!m_states.Contains(state))
                throw new ArgumentException("state");
            CurrentState = state;
        }

        public DojoState CurrentState
        {
            get { return m_currentState; }
            private set { Set(() => CurrentState, ref m_currentState, value); }
        }
    }
}
