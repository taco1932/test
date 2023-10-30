using System;
using System.Collections.Generic;

namespace VfxEditor.FileManager {
    public class GenericListCommand<T> : ICommand {
        protected readonly Action OnChangeAction;
        protected readonly List<T> Items;
        protected readonly List<T> State;
        protected List<T> PrevState;

        public GenericListCommand( List<T> items, IEnumerable<T> state, Action onChangeAction = null ) {
            OnChangeAction = onChangeAction;
            Items = items;
            State = new List<T>( state );
        }

        public virtual void Execute() {
            PrevState = new List<T>( Items );
            Items.Clear();
            Items.AddRange( State );
            OnChangeAction?.Invoke();
        }

        public virtual void Redo() {
            Items.Clear();
            Items.AddRange( State );
            OnChangeAction?.Invoke();
        }

        public virtual void Undo() {
            Items.Clear();
            Items.AddRange( PrevState );
            OnChangeAction?.Invoke();
        }
    }
}
