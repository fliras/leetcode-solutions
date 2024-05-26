namespace _02AddTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {
            bool endOfListNode = l1 == null && l2 == null && carry == 0;
            if (endOfListNode) return null;

            int l1Value = l1 != null ? l1.Val : 0;
            int l2Value = l2 != null ? l2.Val : 0;
            int total = l1Value + l2Value + carry;

            int l3Value = total % 10;
            carry = total / 10;

            return new ListNode(l3Value, AddTwoNumbers(l1?.Next, l2?.Next, carry));
        }
    }
}
