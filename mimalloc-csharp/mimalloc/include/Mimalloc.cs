#pragma warning disable CS1591
#pragma warning disable SYSLIB1054
#pragma warning disable CA1401
#pragma warning disable CA2101

// ReSharper disable ALL

namespace mimalloc
{
    public unsafe struct mi_block_visit_fun
    {
        public delegate* managed<nint, nint, void*, nuint, void*, bool> fun;

        public bool invoke(nint heap, nint area, void* block, nuint block_size, void* arg) => fun(heap, area, block, block_size, arg);

        private mi_block_visit_fun(delegate*<nint, nint, void*, nuint, void*, bool> func) => this.fun = func;
        public static implicit operator mi_block_visit_fun(delegate* managed<nint, nint, void*, nuint, void*, bool> func) => new mi_block_visit_fun(func);
        public static implicit operator delegate* managed<nint, nint, void*, nuint, void*, bool>(mi_block_visit_fun func) => func.fun;
    }

    public unsafe struct mi_deferred_free_fun
    {
        public delegate* managed<bool, ulong, void*, void> fun;

        public void invoke(bool force, ulong heartbeat, void* arg) => fun(force, heartbeat, arg);

        private mi_deferred_free_fun(delegate* managed<bool, ulong, void*, void> func) => this.fun = func;
        public static implicit operator mi_deferred_free_fun(delegate* managed<bool, ulong, void*, void> func) => new mi_deferred_free_fun(func);
        public static implicit operator delegate* managed<bool, ulong, void*, void>(mi_deferred_free_fun func) => func.fun;
    }

    public unsafe struct mi_output_fun
    {
        public delegate* managed<char*, void*, void> fun;

        public void invoke(char* msg, void* arg) => fun(msg, arg);

        private mi_output_fun(delegate* managed<char*, void*, void> func) => this.fun = func;
        public static implicit operator mi_output_fun(delegate* managed<char*, void*, void> func) => new mi_output_fun(func);
        public static implicit operator delegate* managed<char*, void*, void>(mi_output_fun func) => func.fun;
    }

    public unsafe struct mi_error_fun
    {
        public delegate* managed<int, void*, void> fun;

        public void invoke(int err, void* arg) => fun(err, arg);

        private mi_error_fun(delegate* managed<int, void*, void> func) => this.fun = func;
        public static implicit operator mi_error_fun(delegate* managed<int, void*, void> func) => new mi_error_fun(func);
        public static implicit operator delegate* managed<int, void*, void>(mi_error_fun func) => func.fun;
    }

    public enum mi_option_t
    {
        mi_option_show_errors,
        mi_option_show_stats,
        mi_option_verbose,
        mi_option_max_errors,
        mi_option_max_warnings,

        mi_option_reserve_huge_os_pages,
        mi_option_reserve_huge_os_pages_at,
        mi_option_reserve_os_memory,
        mi_option_allow_large_os_pages,
        mi_option_purge_decommits,
        mi_option_arena_reserve,
        mi_option_os_tag,
        mi_option_retry_on_oom,

        mi_option_eager_commit,
        mi_option_eager_commit_delay,
        mi_option_arena_eager_commit,
        mi_option_abandoned_page_purge,
        mi_option_purge_delay,
        mi_option_use_numa_nodes,
        mi_option_disallow_os_alloc,
        mi_option_limit_os_alloc,
        mi_option_max_segment_reclaim,
        mi_option_destroy_on_exit,
        mi_option_arena_purge_mult,
        mi_option_abandoned_reclaim_on_free,
        mi_option_purge_extend_delay,
        mi_option_disallow_arena_alloc,
        mi_option_visit_abandoned,

        _mi_option_last
    }
}