﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUCC.MemoryFiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SUCC.Tests
{
    [TestClass]
    public class SaveLoad_CollectionTypeTests
    {
        const string SAVED_VALUE_KEY = "test key";

        [TestMethod]
        public void SaveLoad_Array_Ints()
        {
            var SAVED_VALUE = new int[] { 0, 1, 2, 3 };
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<int[]>(SAVED_VALUE_KEY);

            CollectionAssert.AreEqual(SAVED_VALUE, loadedValue);
        }

        [TestMethod]
        public void SaveLoad_List_Ints()
        {
            var SAVED_VALUE = new List<int>() { 0, 1, 2, 3 };
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<List<int>>(SAVED_VALUE_KEY);

            CollectionAssert.AreEqual(SAVED_VALUE, loadedValue);
        }

        [TestMethod]
        public void SaveLoad_HashSet_Ints()
        {
            var SAVED_VALUE = new HashSet<int>() { 0, 1, 2, 3 };
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<HashSet<int>>(SAVED_VALUE_KEY);

            Assert.IsTrue(SAVED_VALUE.SequenceEqual(loadedValue));
        }



        [TestMethod]
        public void SaveLoad_Array_DeeplyNestedInts()
        {
            var SAVED_VALUE = DeeplyNestedIntArray;
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<int[][][][]>(SAVED_VALUE_KEY);

            for (int i = 0; i < loadedValue.Length; i++)
                for (int j = 0; j < loadedValue[i].Length; j++)
                    for (int k = 0; k < loadedValue[i][j].Length; k++)
                        CollectionAssert.AreEqual(loadedValue[i][j][k], SAVED_VALUE[i][j][k]);
        }



        [TestMethod]
        public void SaveLoad_Dictionary_StringToInt()
        {
            var SAVED_VALUE = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3,
            };
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<Dictionary<string, int>>(SAVED_VALUE_KEY);

            CollectionAssert.AreEquivalent(SAVED_VALUE, loadedValue);
        }

        [TestMethod]
        public void SaveLoad_Dictionary_ComplexTypeToComplexType()
        {
            var SAVED_VALUE = new Dictionary<ComplexType, ComplexType>()
            {
                [new ComplexType(832, "jfhkdslfjsd", true)] = new ComplexType(22323, Environment.NewLine, false),
                [new ComplexType(int.MaxValue, "oof ouch owie my unit test", false)] = new ComplexType(int.MinValue, "penis lmao", true),
                [new ComplexType(8564698, "I like socialized healthcare", true)] = new ComplexType(99999, "aaaaaaaaaaaaaaaaa", true),
            };
            var file = new MemoryDataFile();

            file.Set(SAVED_VALUE_KEY, SAVED_VALUE);
            var loadedValue = file.Get<Dictionary<ComplexType, ComplexType>>(SAVED_VALUE_KEY);

            CollectionAssert.AreEquivalent(SAVED_VALUE, loadedValue);
        }



        static readonly int[][][][] DeeplyNestedIntArray = new int[][][][]
        {
            new int[][][]
            {
                new int[][]
                {
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                    new int[]
                    {
                        110, 101, 105, 108, 99, 105, 99, 46, 99, 111, 109, 47, 109, 111, 117, 116, 104, 109, 111, 111, 100, 115
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                },
                new int[][]
                {
                    new int[]
                    {
                        104, 116, 116, 112, 58, 47, 47, 115, 117, 99, 99, 46, 115, 111, 102, 116, 119, 97, 114, 101, 47
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 119, 48, 97, 99, 110, 102, 108, 87, 114, 90, 52
                    },
                },
            },
            new int[][][]
            {
                new int[][]
                {
                    new int[]
                    {
                        115, 117, 103, 97, 110, 100, 101, 115, 101, 32, 110, 117, 116, 115, 32, 108, 109, 97, 111
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                },
                new int[][]
                {
                    new int[]
                    {
                        119, 111, 117, 108, 100, 32, 121, 111, 117, 32, 97, 99, 99, 101, 112, 116, 32, 111, 110, 101, 32, 109, 105, 108, 108, 105, 111, 110, 32, 100, 111, 108, 108, 97, 114, 115, 32, 102, 111, 114, 32, 111, 110, 101, 32, 116, 104, 111, 117, 115, 97, 110, 100, 32, 114, 97, 110, 100, 111, 109, 32, 112, 101, 111, 112, 108, 101, 32, 116, 111, 32, 100, 105, 101, 63
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                    new int[]
                    {
                        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47, 119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
                    },
                },
            }
        };
    }
}