﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Resumes a follower index that has been paused either explicitly with the pause follower API or
		/// implicitly due to execution that can not be retried due to failure during following. When this API returns,
		/// the follower index will resume fetching operations from the leader index.
		/// </summary>
		IResumeFollowIndexResponse ResumeFollowIndex(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		IResumeFollowIndexResponse ResumeFollowIndex(IResumeFollowIndexRequest request);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IResumeFollowIndexRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		public IResumeFollowIndexResponse ResumeFollowIndex(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null) =>
			ResumeFollowIndex(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index)));

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		public IResumeFollowIndexResponse ResumeFollowIndex(IResumeFollowIndexRequest request) =>
			DoRequest<IResumeFollowIndexRequest, ResumeFollowIndexResponse>(request, request.RequestParameters);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		public Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(
			IndexName index,
			Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null,
			CancellationToken ct = default
		) => ResumeFollowIndexAsync(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index)), ct);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest.ResumeFollowIndexDescriptor,Nest.IResumeFollowIndexRequest})" />
		public Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IResumeFollowIndexRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IResumeFollowIndexRequest, IResumeFollowIndexResponse, ResumeFollowIndexResponse>(request, request.RequestParameters, ct);
	}
}
