﻿using Moq;
using SolrExpress.Core.Query.Parameter;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolrExpress.Core.Extension.Internal
{
    public class InformationExtensionTests
    {
        /// <summary>
        /// Where   Using StatisticExtension class
        /// When    Invoking the method "Calculate" using offset=1, limit=100, page=1, documents=200
        /// What    Configure statistic instance with correct values
        /// </summary>
        [Fact]
        public void StatisticExtension001()
        {
            // Arrange
            var offsetParameterMock = new Mock<IOffsetParameter>();
            var limitParameterMock = new Mock<ILimitParameter>();

            offsetParameterMock.SetupGet(q => q.Value).Returns(0);
            limitParameterMock.SetupGet(q => q.Value).Returns(100);

            var list = new List<IParameter>
            {
                offsetParameterMock.Object,
                limitParameterMock.Object
            };

            // Act
            var statistic = InformationExtension.Calculate(null, list, 1, 200);

            // Assert
            Assert.Equal(200, statistic.DocumentCount);
            Assert.Equal(new TimeSpan(0, 0, 0, 0, 1), statistic.ElapsedTime);
            Assert.Equal(true, statistic.HasNextPage);
            Assert.Equal(false, statistic.HasPreviousPage);
            Assert.Equal(true, statistic.IsFirstPage);
            Assert.Equal(false, statistic.IsLastPage);
            Assert.Equal(2, statistic.PageCount);
            Assert.Equal(1, statistic.PageNumber);
            Assert.Equal(100, statistic.PageSize);
        }

        /// <summary>
        /// Where   Using StatisticExtension class
        /// When    Invoking the method "Calculate" using offset=1, limit=100, page=1, documents=201
        /// What    Configure statistic instance with correct values
        /// </summary>
        [Fact]
        public void StatisticExtension002()
        {
            // Arrange
            var offsetParameterMock = new Mock<IOffsetParameter>();
            var limitParameterMock = new Mock<ILimitParameter>();

            offsetParameterMock.SetupGet(q => q.Value).Returns(0);
            limitParameterMock.SetupGet(q => q.Value).Returns(100);

            var list = new List<IParameter>
            {
                offsetParameterMock.Object,
                limitParameterMock.Object
            };

            // Act
            var statistic = InformationExtension.Calculate(null, list, 1, 201);

            // Assert
            Assert.Equal(201, statistic.DocumentCount);
            Assert.Equal(new TimeSpan(0, 0, 0, 0, 1), statistic.ElapsedTime);
            Assert.Equal(true, statistic.HasNextPage);
            Assert.Equal(false, statistic.HasPreviousPage);
            Assert.Equal(true, statistic.IsFirstPage);
            Assert.Equal(false, statistic.IsLastPage);
            Assert.Equal(3, statistic.PageCount);
            Assert.Equal(1, statistic.PageNumber);
            Assert.Equal(100, statistic.PageSize);
        }

        /// <summary>
        /// Where   Using StatisticExtension class
        /// When    Invoking the method "Calculate" using offset=1, limit=100, page=1, documents=0
        /// What    Configure statistic instance with correct values
        /// </summary>
        [Fact]
        public void StatisticExtension003()
        {
            // Arrange
            var offsetParameterMock = new Mock<IOffsetParameter>();
            var limitParameterMock = new Mock<ILimitParameter>();

            offsetParameterMock.SetupGet(q => q.Value).Returns(0);
            limitParameterMock.SetupGet(q => q.Value).Returns(100);

            var list = new List<IParameter>
            {
                offsetParameterMock.Object,
                limitParameterMock.Object
            };

            // Act
            var statistic = InformationExtension.Calculate(null, list, 1, 0);

            // Assert
            Assert.Equal(0, statistic.DocumentCount);
            Assert.Equal(new TimeSpan(0, 0, 0, 0, 1), statistic.ElapsedTime);
            Assert.Equal(false, statistic.HasNextPage);
            Assert.Equal(false, statistic.HasPreviousPage);
            Assert.Equal(true, statistic.IsFirstPage);
            Assert.Equal(true, statistic.IsLastPage);
            Assert.Equal(0, statistic.PageCount);
            Assert.Equal(1, statistic.PageNumber);
            Assert.Equal(100, statistic.PageSize);
        }
    }
}
