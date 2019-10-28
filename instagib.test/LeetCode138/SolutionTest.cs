using instagib.LeetCode138;
using Xunit;
using Xunit.Abstractions;

namespace instagib.test.LeetCode138
{
    public class SolutionTest
    {
        public SolutionTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public void Leetcode_138_test()
        {
            var fst = new Node {val = 1};
            var snd = new Node {val = 2};
            var thrd = new Node {val = 3};
            var frth = new Node {val = 6};
            fst.next = snd;
            fst.random = fst;
            snd.next = thrd;
            snd.random = fst;
            thrd.random = snd;
            thrd.next = frth;
            var sln = new Solution();
            _testOutputHelper.WriteLine("orig_0");
            foreach (var n in fst) _testOutputHelper.WriteLine(n.ToString());

            var dc = sln.CopyRandomList(fst);
            _testOutputHelper.WriteLine("orig_1");
            foreach (var n in fst) _testOutputHelper.WriteLine(n.ToString());

            _testOutputHelper.WriteLine("copy");
            foreach (var n in dc) _testOutputHelper.WriteLine(n.ToString());

            var fn = fst;
            var dcn = dc;
            for (; fn != null || dcn != null; fn = fn.next, dcn = dcn.next)
                if (fn?.val != dcn?.val)
                    Assert.True(false, $"{fn} != {dcn}");
        }
    }
}