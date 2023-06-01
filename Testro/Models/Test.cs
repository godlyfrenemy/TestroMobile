using MySqlConnector;
using System.Collections.Generic;
using Testro.ViewModels;

namespace Testro.Models
{
    public class TestData : BaseNotify
    {
        public readonly static long UNKNOWN_ID = -1;

        public long TestDataId { get; private set; } = UNKNOWN_ID;
        public long TestTimeConstraint { get; private set; } = 0;
        public long TestQuestionTimeConstraint { get; set; } = 0;
        public long TestTypeConstraintId { get; private set; } = UNKNOWN_ID;
        public string TestTypeName { get; private set; }

        public static TestData CreateTestData(long testDataId)
        {
            TestData testData = new TestData();

            if (testDataId != UNKNOWN_ID)
            {
                testData.TestDataId = testDataId;
                testData.TestTimeConstraint = BaseViewModel.GetDataBaseRequestResult(testData.GetTimeConstraintValue) ?? 0;
                testData.TestQuestionTimeConstraint = BaseViewModel.GetDataBaseRequestResult(testData.GetQuestionTimeConstraintValue) ?? 0;
                testData.TestTypeConstraintId = BaseViewModel.GetDataBaseRequestResult(testData.GetTypeConstraintValue) ?? UNKNOWN_ID;
                testData.TestTypeName = BaseViewModel.GetDataBaseRequestResult(testData.GetTypeConstraintName);
            }

            return testData;
        }

        private long? GetTimeConstraintValue(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests_data` WHERE `test_data_id` = '" + TestDataId + "'";
            return BaseViewModel.GetFirstValue<long>(query, connection, "test_time_constraint");
        }

        private long? GetQuestionTimeConstraintValue(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests_data` WHERE `test_data_id` = '" + TestDataId + "'";
            return BaseViewModel.GetFirstValue<long>(query, connection, "test_question_time_constraint");
        }

        private long? GetTypeConstraintValue(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests_data` WHERE `test_data_id` = '" + TestDataId + "'";
            return BaseViewModel.GetFirstValue<long>(query, connection, "test_type_constraint_id");
        }

        private string GetTypeConstraintName(MySqlConnection connection)
        {
            string query = "SELECT * FROM `test_types` WHERE `test_type_id` = '" + TestTypeConstraintId + "'";
            return BaseViewModel.GetFirstValue<string>(query, connection, "test_type_name");
        }
    }

    public class Test : BaseNotify
    {
        public readonly static long UNKNOWN_ID = -1;

        public long TestId { get; set; } = UNKNOWN_ID;
        public TestData TestData { get; set; } = new TestData();

        private string _testName = string.Empty;
        public string TestName
        {
            get => _testName;
            set
            {
                SetProperty(ref _testName, value);
            }
        }

        public int TestMark { get; set; }

        public List<Question> Questions { get; set; }

        public static Test CreateTest(long testId, bool withMistakesOnly = false)
        {
            Test test = new Test();

            if (testId != UNKNOWN_ID)
            {
                test.TestId = testId;
                test.TestMark = BaseViewModel.GetDataBaseRequestResult(test.GetTestMark);
                test.TestName = BaseViewModel.GetDataBaseRequestResult(test.GetTestName);
                test.TestData = test.GetTestData();
                test.Questions = test.GetQuestions(withMistakesOnly);
            }
            return test;
        }

        private long? GetTestDataId(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests` WHERE `test_id` = '" + TestId + "'";
            return BaseViewModel.GetFirstValue<long>(query, connection, "test_data_id");
        }
        protected string GetTestName(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests` WHERE `test_id` = '" + TestId + "'";
            return BaseViewModel.GetFirstValue<string>(query, connection, "test_name");
        }

        protected int GetTestMark(MySqlConnection connection)
        {
            string query = "SELECT * FROM `tests` WHERE `test_id` = '" + TestId + "'";
            return BaseViewModel.GetFirstValue<int>(query, connection, "test_mark");
        }

        protected TestData GetTestData()
        {
            long testDataId = BaseViewModel.GetDataBaseRequestResult(GetTestDataId) ?? UNKNOWN_ID;
            return TestData.CreateTestData(testDataId);
        }

        protected virtual List<Question> GetQuestions(bool withMistakesOnly)
        {
            List<long> questionIds = withMistakesOnly ?
                                    BaseViewModel.GetDataBaseRequestResult(GetTestQuestionIdsWithMistakes) :
                                    BaseViewModel.GetDataBaseRequestResult(GetTestQuestionIds);
            List<Question> questions = new List<Question>();

            questionIds.ForEach(delegate (long questionId)
            {
                questions.Add(Question.CreateQuestion(questionId));
            });

            return questions;
        }

        protected List<long> GetTestQuestionIds(MySqlConnection connection)
        {
            string query = "SELECT * FROM `test_questions` WHERE `test_id` = '" + TestId + "'";
            return BaseViewModel.GetAllValues<long>(query, connection, "question_id");
        }

        protected List<long> GetTestQuestionIdsWithMistakes(MySqlConnection connection)
        {
            string query = "CALL GetTestQuestionsWithMistakes('" + TestId + "', '" + User.UserId + "');";
            return BaseViewModel.GetAllValues<long>(query, connection, "question_id");
        }
    }
}
