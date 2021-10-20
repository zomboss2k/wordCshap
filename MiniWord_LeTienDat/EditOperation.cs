using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniWord_LeTienDat
{
    public class EditOperation
    {
        private UndoRedoClass data;
        private bool rtxbContentTextChangeRequired = true;
        public EditOperation()
        {
            data = new UndoRedoClass();
        }

        public bool RtxbContentTextChangeRequired
        {
            get
            {
                return rtxbContentTextChangeRequired;
            }

            set
            {
                rtxbContentTextChangeRequired = value;
            }
        }

        public string DateTime_Now()
        {
            return DateTime.Now.ToString();
        }

        public string UndoClicked()
        {
            RtxbContentTextChangeRequired = false;
            return data.Undo();
        }

        public string RedoClicked()
        {
            RtxbContentTextChangeRequired = false;
            return data.Redo();
        }

        public void Add_UndoRedo(string item)
        {
            data.AddItem(item);
        }

        public bool CanUndo()
        {
            return data.CanUndo();
        }

        public bool CanRedo()
        {
            return data.CanRedo();
        }

        public FindNextResult FindNext(FindNextSearch search)
        {
            FindNextResult result = new FindNextResult();
            int position = -1;
            StringComparison s = search.MatchCase ? StringComparison.CurrentCulture :
                StringComparison.CurrentCultureIgnoreCase;
            if (search.Direction == "UP")
            {
                position = search.Content.Substring(0, search.Position)
                    .LastIndexOf(search.SearchString, s);
                search.Success = position >= 0 ? true : false;
                result.SearchStatus = search.Success;
            }
            else
            {
                int start = search.Success ? search.Position + search.SearchString.Length :
                    search.Position;
                position = start + search.Content
                    .Substring(start, search.Content.Length - start)
                    .IndexOf(search.SearchString, s);
                search.Success = position - start >= 0 ? true : false;
                result.SearchStatus = search.Success;
            }
            result.SelectionStart = result.SearchStatus ? position : -1;
            return result;
        }
    }
}
