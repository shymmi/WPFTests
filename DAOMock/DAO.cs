using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock
{
    public class DAO : IDAO
    {
        private List<IUser> _users;
        private List<ITest> _tests;

        public DAO()
        {
            _users = new List<IUser>()
            {
                new BO.User() {CanEdit = false, NickName = "User", Password = "upass", OngoingTest = null, SolvedTests = null },
                new BO.User() {CanEdit = true, NickName = "Editor", Password = "epass", OngoingTest = null, SolvedTests = null }
            };

            _tests = new List<ITest>()
            {
                new BO.Test()
                {
                    ID = 1, IsMultiAnswer = false, RatingType = null, Minutes = 5, Title = "Animals", Questions = new List<IQuestion>
                    {
                        new BO.Question {ID = 1, MaxPoints = 1, Text = "How many legs does a dog have?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = false, Text = "Four", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = true, Text = "Depends", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Six", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Two", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 2, MaxPoints = 1, Text = "How fast can a cheetah run?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = false, Text = "10 km/h", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "45 km/h", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "30 km/h", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = true, Text = "80 km/h", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 3, MaxPoints = 1, Text = "Which of the following is the smallest?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Snail", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Whale", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Cat", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Rhino", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 4, MaxPoints = 1, Text = "Who lives in the forest?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Hamster", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Deer", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Shark", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Eagle", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 5, MaxPoints = 1, Text = "What are hamburgers usually made of?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Chicken", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Pork", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Lamb", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Beef", IsSelected = false  }
                            }
                        }

                    }
                },

                new BO.Test()
                {
                    ID = 2, IsMultiAnswer = true, RatingType = null, Minutes = 6, Title = "Math", Questions = new List<IQuestion>
                    {
                        new BO.Question {ID = 1, MaxPoints = 2, Text = "How many legs does a dog have?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = false, Text = "Four", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = true, Text = "Depends", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Six", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Two", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 2, MaxPoints = 1, Text = "How fast can a cheetah run?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = false, Text = "10 km/h", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "45 km/h", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "30 km/h", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = true, Text = "80 km/h", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 3, MaxPoints = 1, Text = "Which of the following is the smallest?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Snail", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Whale", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Cat", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Rhino", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 4, MaxPoints = 1, Text = "Who lives in the forest?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Hamster", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Deer", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Shark", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Eagle", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 5, MaxPoints = 1, Text = "What are hamburgers usually made of?", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "Chicken", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "Pork", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "Lamb", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = false, Text = "Beef", IsSelected = false  }
                            }
                        },
                        new BO.Question {ID = 5, MaxPoints = 1, Text = "sum of 5 and 6", Answers = new List<IAnswer>
                            {
                                new BO.Answer {ID = 1, IsCorrect = true, Text = "equals 11", IsSelected = false },
                                new BO.Answer {ID = 2, IsCorrect = false, Text = "is greater than 4 * 3", IsSelected = false  },
                                new BO.Answer {ID = 3, IsCorrect = false, Text = "squared equals 123", IsSelected = false  },
                                new BO.Answer {ID = 4, IsCorrect = true, Text = "is a whole number", IsSelected = false  }
                            }
                        }

                    }
                }
            };
        }


        public void AddTest(ITest test)
        {
            _tests.Add(test);
        }

        public ITest CreateNewTest()
        {
            return new BO.Test();
        }

        public IEnumerable<ITest> GetAllTests()
        {
            return _tests;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _users;
        }
    }
}
