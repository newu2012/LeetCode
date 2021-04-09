using System.Collections.Generic;
using LeetCode;
using NUnit.Framework;

namespace LeetCode {
    public class ListNode {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }

        public string Print() {
            var result = val.ToString();
            var node = next;
            
            while (node != null) {
                result += node.val;
                node = node.next;
            }

            return result;
        }
    }

    public class AddTwoNumbersTask {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var result = new ListNode();
            var carry = 0;
            var current = result;
            var p = l1;
            var q = l2;
            
            while (p != null || q != null) {
                var x = p?.val ?? 0;
                var y = q?.val ?? 0;
                var sum = x + y + carry;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
                p = p?.next;
                q = q?.next;
            }

            if (carry > 0)
                current.next = new ListNode(carry);
            return result.next;
        }
    }
}

namespace LeetCodeTests {
    [TestFixture]
    public class AddTwoNumbersTests {
        [Test]
        public void Test1() {
            var task = new AddTwoNumbersTask();
            
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            
            var expected = new ListNode(7, new ListNode(0, new ListNode(8)));
            var result = task.AddTwoNumbers(l1, l2);
            Assert.AreEqual(expected.Print(), result.Print(), $"expected:{expected.Print()}, result:{result.Print()}.");
        }
        
        [Test]
        public void Test2() {
            var task = new AddTwoNumbersTask();
            
            var l1 = new ListNode();
            var l2 = new ListNode();

            var expected = new ListNode();
            var result = task.AddTwoNumbers(l1, l2);
            Assert.AreEqual(expected.Print(), result.Print(), $"expected:{expected.Print()}, result:{result.Print()}.");
        }
        
        [Test]
        public void Test3() {
            var task = new AddTwoNumbersTask();
            
            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

            var expected = new ListNode(8,
                new ListNode(9,
                    new ListNode(9,
                        new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))));
            var result = task.AddTwoNumbers(l1, l2);
            Assert.AreEqual(expected.Print(), result.Print(), $"expected:{expected.Print()}, result:{result.Print()}.");
        }
    }
}