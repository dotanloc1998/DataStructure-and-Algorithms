using System;

namespace DSA
{
	class BTreeInt
	{
		class Entry
		{
			public int key;
			public float data;
			public Node right;
			
			public Entry(int key, float data, Node right=null)
			{
				this.key = key;
				this.data = data;
				this.right = right;
			}
			public Entry(Entry entry)
			{
				key = entry.key;
				data = entry.data;
				right = entry.right;
			}
			public Entry(Entry entry, Node right)
			{
				key = entry.key;
				data = entry.data;
				this.right = right;
			}
		}
		class Node
		{
			public Node first;
			public int count;
			public Entry[] entries;

			public int _width;
			public string _text;
			
			public Node(Node first, Entry right, int degree)
			{
				this.first = first;
				this.entries = new Entry[degree-1];
				this.entries[0] = right;
				this.count = 1;
				_updateText();
			}
			public void _show(int highlight)
			{
				Console.Write("[");
				for (int i = 0; i < count; i++)
				{
					Console.ResetColor();
					if (i > 0) Console.Write(",");
					if (entries[i].key == highlight)
						Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(entries[i].key);
				}
				Console.ResetColor();
				Console.Write("]");
			}
			public void _updateText()
			{
				_text = GetToString();
			}
			public int _calWidth()
			{
				_updateText();
				if (IsLeaf)
				{
					return _width = _text.Length + 1;
				}
				else
				{
					_width = first._calWidth();
					for (int i = 0; i < count; i++)
					{
						_width += entries[i].right._calWidth();
					}
					return _width;
				}
			}
			public string GetToString()
			{
				int[] keys = new int[count];
				for (int i = 0; i < count; i++)
				{
					keys[i] = entries[i].key;
				}
				return "[" + String.Join(",", keys) + "]";
			}

			public bool IsLeaf { get { return first == null; } }
			public bool IsMiss { get { return count < entries.Length / 2; } }
			public bool IsDonatable { get { return count > entries.Length / 2; } }
			public bool IsFull { get { return count == entries.Length; } }

			public int Search(int key)
			{
				int i=0;
				for (; i < count && entries[i].key < key; i++) ;
				return i;
			}
			public void Insert(int pos, Entry entry)
			{
				for(int i = count; i > pos; i--)
					entries[i] = entries[i-1];
				entries[pos] = entry;
				count++;
				_updateText();
			}
			public void Remove(int pos)
			{
				for(int i = pos+1; i < count; i++)
					entries[i-1] = entries[i];
				count--;
				_updateText();
			}
			public Entry Split(int pos)
			{
				Entry mid = new Entry(entries[pos]);
				int degree = entries.Length+1;
				mid.right	= new Node(entries[pos].right, entries[pos+1], degree);
				int i = 1, j = pos+2;
				while(j < count)
					mid.right.entries[i++] = entries[j++];
				mid.right.count = i;
				count -= i+1;
				_updateText();
				return mid;
			}
			public void Merge(int pos, Node left, Node right)
			{
				left.entries[left.count++] = new Entry(entries[pos].key, entries[pos].data, right.first);
				for (int i = 0; i < right.count; i++)
					left.entries[left.count++] = right.entries[i];
				left._updateText();
				Remove(pos);
			}
			public bool Rotate(int pos, Node left, Node right)
			{
				Entry mid = new Entry(entries[pos], right.first);
				if (left.IsMiss && right.IsDonatable) {
					left.Insert(left.count, mid);
					entries[pos] = new Entry(right.entries[0], right);
					right.first = right.entries[0].right;
					right.Remove(0);
					_updateText();
					return true;
				}
				else if (left.IsDonatable && right.IsMiss){
					right.Insert(0, mid);
					entries[pos] = new Entry(left.entries[left.count - 1], right);
					right.first = left.entries[left.count - 1].right;
					left.Remove(left.count - 1);
					_updateText();
					return true;
				}
				return false;
			}
		}
		int degree;
		Node root;
		public BTreeInt(int degree)
		{
			this.degree = (degree % 2 == 0) ? degree+1 : degree;
			root = null;
		}
		public void LNR(Func<float, int> fp)
		{
			if (fp != null)
				LNR(root, fp);
		}
		private void LNR(Node root, Func<float, int> fp)
		{
			if (root != null && fp != null){
				LNR(root.first, fp);
				for(int i=0; i < root.count; i++){
					fp(root.entries[i].data);
					LNR(root.entries[i].right, fp);
				}
			}
		}
		public bool Search(int key, out float found)
		{
			return Search(root, key, out found);
		}
		private bool Search(Node root, int key, out float found)
		{
			if (root!=null){
				int pos = root.Search(key);
				if (pos < root.count && root.entries[pos].key == key){
					found = root.entries[pos].data;
					return true;
				}
				return Search(pos>0 ? root.entries[pos-1].right : root.first, key, out found);
			} else {
				found = 0.0F;
				return false;
			}
		}
		public void Insert(int key, float data)
		{
			Entry mid = new Entry(key, data);
			if (root == null || Insert(root, mid, out mid))
			{
				root = new Node(root, mid, degree);
			}
		}
		private bool Insert(Node root, Entry entry, out Entry mid)
		{
			mid = null;
			int pos = root.Search(entry.key);
			if (pos < root.count && entry.key == root.entries[pos].key)
				return false;
			Node child = pos > 0 ? root.entries[pos - 1].right : root.first;
			if (root.IsLeaf == false) {
				if (Insert(child, entry, out mid) == false)
					return false;
				entry = mid;
			}
			if (!root.IsFull)
			{
				root.Insert(pos, entry);
				return false;
			}
			int d2 = degree / 2;
			if (pos < d2)
			{
				mid = root.Split(d2-1);
				root.Insert(pos, entry);
			}
			else if (pos == d2)
			{
				mid = root.Split(d2-1);
				root.count++;//giữ lại key tại vị trí d2-1
				mid.right.first = entry.right;
				mid.key = entry.key;
				mid.data = entry.data;
			}
			else
			{
				mid = root.Split(d2);
				mid.right.Insert(pos-d2-1, entry);
			}
			return true;
		}

		public void Remove(int key)
		{
			if (root != null && Remove(root, key) && root.count == 0)
				root = root.first;
		}
		private bool Remove(Node root, int key)
		{
			if (root == null) return false;
			int pos = root.Search(key);
			if (pos < root.count && key == root.entries[pos].key)
			{
				if (root.IsLeaf)
				{
					root.Remove(pos);
					return root.IsMiss;
				}
				else
				{
					Node tleft = pos > 0 ? root.entries[pos - 1].right : root.first;
					while (tleft.IsLeaf == false)
						tleft = tleft.entries[tleft.count - 1].right;
					Entry dest = root.entries[pos], source = tleft.entries[tleft.count - 1];
					dest.key = source.key;
					dest.data = source.data;
					root._updateText();
					if (Remove(pos > 0 ? root.entries[pos - 1].right : root.first, source.key) == false)
						return false;
				}
			}
			else if (Remove(pos > 0 ? root.entries[pos - 1].right : root.first, key) == false)
				return false;
			//Xử lý thiếu khóa
			Node left, right;
			if (pos == root.count)
				pos--;
			left = pos > 0 ? root.entries[pos - 1].right : root.first;
			right = root.entries[pos].right;
			if (root.Rotate(pos, left, right))
				return false;
			root.Merge(pos, left, right);
			return root.IsMiss;
		}
		public void _Show(int line=1, int highlight=0)
		{
			if (root != null)
			{
				root._calWidth();
			}
			_Show(root, 0, line, highlight);
		}
		private void _Show(Node root, int left, int deep, int highlight)
		{
			if (root != null)
			{
				if (!root.IsLeaf)
				{
					_Show(root.first, left, deep + 1, highlight);
					left += root.first._width;
					Console.SetCursorPosition(left + 1, deep);
					root._show(highlight);
					for (int i = 0; i < root.count; i++)
					{
						_Show(root.entries[i].right, left, deep + 1, highlight);
						left += root.entries[i].right._width;
					}
				}
				else
				{
					Console.SetCursorPosition(left + 1, deep);
					root._show(highlight);
				}
			}
		}
	}
}