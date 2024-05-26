namespace _02AddTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3 = new ListNode();
            ListNode currentNode = l3;

            while (l1 != null || l2 != null)
            {
                int l1Value = l1 != null ? l1.Val : 0;
                int l2Value = l2 != null ? l2.Val : 0;

                int l3Value = l1Value + l2Value + currentNode.Val;
                int l3ValueUnits = l3Value % 10;
                int l3ValueTens = l3Value / 10;

                currentNode.Val = l3ValueUnits;
                l1 = l1?.Next;
                l2 = l2?.Next;

                if (l1 != null || l2 != null)
                {
                    currentNode.Next = new ListNode(l3ValueTens);
                    currentNode = currentNode.Next;
                }
                else if (l3ValueTens > 0)
                {
                    currentNode.Next = new ListNode(l3ValueTens);
                }
            }

            return l3;
        }
    }
}
