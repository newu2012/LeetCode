using System;
using LeetCode;
using NUnit.Framework;

namespace LeetCode {
    public class ReverseIntegerTask {
        public int Reverse(int x) {
            var minus = x < 0;

            if (minus)
                x *= -1;

            var reversed = 0L;
            while (x > 0) {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }

            return reversed > int.MaxValue ? 0 : 
                minus ? (int) (-1 * reversed) : (int) reversed;
        }
    }
}
namespace LeetCodeTests {
    [TestFixture]
    public class ReverseIntegerTaskTest {
        private ReverseIntegerTask _task;

        [SetUp]
        public void SetUp() {
            _task = new ReverseIntegerTask();
        }
        
        [Test]
        public void Example1() {
            Assert.AreEqual(_task.Reverse(123), 321);
        }
        
        [Test]
        public void Example2() {
            Assert.AreEqual(_task.Reverse(-123), -321);
        }
        
        [Test]
        public void Example3() {
            Assert.AreEqual(_task.Reverse(120), 21);
        }
        
        [Test]
        public void Example4() {
            Assert.AreEqual(_task.Reverse(0), 0);
        }
        
        [Test]
        public void BigNumber() {
            Assert.AreEqual(_task.Reverse(int.MaxValue), 0);
        }
    }
}