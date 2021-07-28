using LeetCode;
using NUnit.Framework;

namespace LeetCode {
    public class PalindromeNumberTask {
        public bool IsPalindrome(int x) {
            if (x < 0 || x % 10 == 0 && x != 0)
                return false;

            var rev = 0;
            while (x > rev) {
                rev = rev * 10 + x % 10;
                x /= 10;
            }

            return x == rev || x * 10 + rev % 10 == rev;
        }
    
    }
}

namespace LeetCodeTests {
    [TestFixture]
    public class PalindromeNumberTaskTests {
        private PalindromeNumberTask _task;

        [SetUp]
        public void SetUp() {
            _task = new PalindromeNumberTask();
        }

        [Test]
        public void Example1() {
            Assert.AreEqual(_task.IsPalindrome(121), true);
        }
        
        [Test]
        public void Example2() {
            Assert.AreEqual(_task.IsPalindrome(-121), false, "From left to right, it reads -121. " +
                                                           "From right to left, it becomes 121-. " +
                                                           "Therefore it is not a palindrome.");
        }
        
        [Test]
        public void Example3() {
            Assert.AreEqual(_task.IsPalindrome(10), false, "Reads 01 from right to left. " +
                                                         "Therefore it is not a palindrome.");
        }
        
        [Test]
        public void Example4() {
            Assert.AreEqual(_task.IsPalindrome(-101), false);
        }

        [Test]
        public void Test1() {
            Assert.AreEqual(_task.IsPalindrome(12321), true);
        }
        
        [Test]
        public void Test2() {
            Assert.AreEqual(_task.IsPalindrome(123321), true);
        }
    }
}