using System.Collections.Generic;

namespace instagib.LeetCode138
{
    // Definition for a Node.
    // those are copied from leetcode and a bit extended
    // so code style might be a bit unusual
    public class Node
    {
        public Node()
        {
        }

        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }

        public Node next { get; set; }
        public Node random { get; set; }
        public int val { get; set; }

        public override string ToString()
        {
            return $"Val: {val}, Next: {next?.val}, Rnd: {random?.val}";
        }

        public static bool operator ==(Node lhs, Node rhs)
        {
            return lhs?.val == rhs?.val && lhs?.next?.val == rhs?.next?.val
                                        && lhs?.random?.val == rhs?.random?.val;
        }

        public static bool operator !=(Node lhs, Node rhs)
        {
            return !(lhs == rhs);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            var i = this;
            while (i != null)
            {
                yield return i;
                i = i.next;
            }
        }

//        public IEnumerator GetEnumerator()
//        {
//            throw new System.NotImplementedException();
//        }
    }

    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            for (var n = head; n != null; n = n.next.next)
            {
                var copy = new Node();
                copy.val = n.val;
                copy.next = n.next;
                n.next = copy;
            }

            var headc = head.next;
            for (Node io = head, ic = head.next; io != null; io = ic.next, ic = ic.next?.next)
                ic.random = io.random?.next;

            for (Node io = head, ic = head.next; io != null;)
            {
                var o = io;
                var c = ic;
                io = io.next?.next;
                ic = ic?.next?.next;
                o.next = io;
                c.next = ic;
            }

            return headc;
        }
    }
}