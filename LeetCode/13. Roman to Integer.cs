using LeetCode;
using NUnit.Framework;

namespace LeetCode {
    /*
    Symbol        Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000
    */
    
    public class RomanToIntegerTask {
        public int RomanToInt(string s) {
            var nums = new int[s.Length];

            for (var i = 0; i < s.Length; i++) {
                nums[i] = s[i] switch {
                    'M' => 1000,
                    'D' => 500,
                    'C' => 100,
                    'L' => 50,
                    'X' => 10,
                    'V' => 5,
                    'I' => 1,
                    _ => nums[i]
                };
            }

            var sum = 0;
            for (var i = 0; i < s.Length - 1; i++) {
                sum += nums[i] < nums[i + 1] ? -nums[i] : nums[i];
            }

            return sum + nums[^1];
        }
    }
}

namespace LeetCodeTests {
    [TestFixture]
    public class RomanToIntegerTaskTests {
        private RomanToIntegerTask _task;

        [SetUp]
        public void SetUp() {
            _task = new RomanToIntegerTask();
        }

        [Test]
        public void Example1() {
            Assert.AreEqual(3, _task.RomanToInt("III"));
        }
        
        [Test]
        public void Example2() {
            Assert.AreEqual(4, _task.RomanToInt("IV"));
        }
        
        [Test]
        public void Example3() {
            Assert.AreEqual(9, _task.RomanToInt("IX"), "L = 50, V= 5, III = 3.");
        }
        
        [Test]
        public void Example4() {
            Assert.AreEqual(58, _task.RomanToInt("LVIII"));
        }
        
        [Test]
        public void Example5() {
            Assert.AreEqual(1994, _task.RomanToInt("MCMXCIV"), "M = 1000, CM = 900, XC = 90 and IV = 4.");
        }
    }
}