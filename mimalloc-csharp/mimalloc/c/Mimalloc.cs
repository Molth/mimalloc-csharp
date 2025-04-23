using System.Runtime.InteropServices;
using System.Security;

#pragma warning disable CS1591
#pragma warning disable SYSLIB1054
#pragma warning disable CA1401
#pragma warning disable CA2101

// ReSharper disable ALL

namespace mimalloc
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe class Mimalloc
    {
        private const string NATIVE_LIBRARY = "mimalloc";

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_malloc(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_calloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_calloc(nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_realloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_realloc(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_expand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_expand(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_free(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_strdup", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_strdup(sbyte* s);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_strndup", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_strndup(sbyte* s, nuint n);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_realpath", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_realpath(sbyte* fname, sbyte* resolved_name);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc_small", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_malloc_small(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_zalloc_small", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_zalloc_small(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_zalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_zalloc(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_mallocn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_mallocn(nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reallocn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_reallocn(void* p, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reallocf", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_reallocf(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_usable_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern nuint mi_usable_size(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_good_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern nuint mi_good_size(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_register_deferred_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_register_deferred_free(mi_deferred_free_fun fn, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_register_output", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_register_output(mi_output_fun @out, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_register_error", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_register_error(mi_error_fun fun, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_collect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_collect(bool force);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_version", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_version();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_stats_reset", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_stats_reset();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_stats_merge", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_stats_merge();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_stats_print", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_stats_print(mi_output_fun @out);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_stats_print_out", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_stats_print_out(mi_output_fun @out, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_thread_done", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_thread_done();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_thread_stats_print_out", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_thread_stats_print_out(mi_output_fun @out, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_process_info", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_process_info(nuint* elapsed_msecs, nuint* user_msecs, nuint* system_msecs, nuint* current_rss, nuint* peak_rss, nuint* current_commit, nuint* peak_commit, nuint* page_faults);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_malloc_aligned(nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_malloc_aligned_at(nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_zalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_zalloc_aligned(nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_zalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_zalloc_aligned_at(nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_calloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_calloc_aligned(nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_calloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_calloc_aligned_at(nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_mallocn_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_mallocn_aligned(nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_mallocn_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_mallocn_aligned_at(nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_realloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_realloc_aligned(void* p, nuint newsize, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_realloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_realloc_aligned_at(void* p, nuint newsize, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reallocn_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_reallocn_aligned(void* p, nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reallocn_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_reallocn_aligned_at(void* p, nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint mi_heap_new();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_delete", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_heap_delete(nint heap);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_destroy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_heap_destroy(nint heap);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_set_default", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint mi_heap_set_default(nint heap);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_get_default", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint mi_heap_get_default();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_get_backing", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint mi_heap_get_backing();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_collect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_heap_collect(nint heap, bool force);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_malloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_malloc(nint heap, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_zalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_zalloc(nint heap, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_calloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_calloc(nint heap, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_mallocn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_mallocn(nint heap, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_malloc_small", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_malloc_small(nint heap, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_realloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_realloc(nint heap, void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_reallocn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_reallocn(nint heap, void* p, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_reallocf", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_reallocf(nint heap, void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_strdup", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_heap_strdup(nint heap, sbyte* s);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_strndup", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_heap_strndup(nint heap, sbyte* s, nuint n);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_realpath", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* mi_heap_realpath(nint heap, sbyte* fname, sbyte* resolved_name);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_malloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_malloc_aligned(nint heap, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_malloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_malloc_aligned_at(nint heap, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_zalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_zalloc_aligned(nint heap, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_zalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_zalloc_aligned_at(nint heap, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_calloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_calloc_aligned(nint heap, nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_calloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_calloc_aligned_at(nint heap, nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_mallocn_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_mallocn_aligned(nint heap, nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_mallocn_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_mallocn_aligned_at(nint heap, nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_realloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_realloc_aligned(nint heap, void* p, nuint newsize, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_realloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_realloc_aligned_at(nint heap, void* p, nuint newsize, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_reallocn_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_reallocn_aligned(nint heap, void* p, nuint count, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_reallocn_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_reallocn_aligned_at(nint heap, void* p, nuint count, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_rezalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_rezalloc(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_recalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_recalloc(void* p, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_rezalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_rezalloc_aligned(void* p, nuint newsize, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_rezalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_rezalloc_aligned_at(void* p, nuint newsize, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_recalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_recalloc_aligned(void* p, nuint newcount, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_recalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_recalloc_aligned_at(void* p, nuint newcount, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_rezalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_rezalloc(nint heap, void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_recalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_recalloc(nint heap, void* p, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_rezalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_rezalloc_aligned(nint heap, void* p, nuint newsize, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_rezalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_rezalloc_aligned_at(nint heap, void* p, nuint newsize, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_recalloc_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_recalloc_aligned(nint heap, void* p, nuint newcount, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_recalloc_aligned_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_heap_recalloc_aligned_at(nint heap, void* p, nuint newcount, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_contains_block", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_heap_contains_block(nint heap, void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_check_owned", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_heap_check_owned(nint heap, void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_check_owned", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_check_owned(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_heap_visit_blocks", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_heap_visit_blocks(nint heap, bool visit_blocks, mi_block_visit_fun visitor, void* arg);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_is_in_heap_region", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_is_in_heap_region(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_is_redirected", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_is_redirected();

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reserve_huge_os_pages_interleave", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_reserve_huge_os_pages_interleave(nuint pages, nuint numa_nodes, nuint timeout_msecs);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reserve_huge_os_pages_at", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_reserve_huge_os_pages_at(nuint pages, int numa_node, nuint timeout_msecs);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reserve_huge_os_pages", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_reserve_huge_os_pages(nuint pages, double max_secs, nuint* pages_reserved);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_is_enabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mi_option_is_enabled(mi_option_t option);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_enable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_enable(mi_option_t option);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_disable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_disable(mi_option_t option);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_set_enabled", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_set_enabled(mi_option_t option, bool enable);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_set_enabled_default", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_set_enabled_default(mi_option_t option, bool enable);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_get", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_option_get(mi_option_t option);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_set", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_set(mi_option_t option, int value);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_option_set_default", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_option_set_default(mi_option_t option, int value);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_cfree", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_cfree(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi__expand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi__expand(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern nuint mi_malloc_size(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_malloc_usable_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern nuint mi_malloc_usable_size(void* p);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_posix_memalign", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_posix_memalign(void** p, nuint alignment, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_memalign", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_memalign(nuint alignment, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_valloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_valloc(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_pvalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_pvalloc(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_aligned_alloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_aligned_alloc(nuint alignment, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_reallocarray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_reallocarray(void* p, nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_aligned_recalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_aligned_recalloc(void* p, nuint newcount, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_aligned_offset_recalloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_aligned_offset_recalloc(void* p, nuint newcount, nuint size, nuint alignment, nuint offset);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_wcsdup", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* mi_wcsdup(ushort* s);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_mbsdup", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* mi_mbsdup(byte* s);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_dupenv_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_dupenv_s(sbyte** buf, nuint* size, sbyte* name);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_wdupenv_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mi_wdupenv_s(ushort** buf, nuint* size, ushort* name);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_free_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_free_size(void* p, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_free_size_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_free_size_aligned(void* p, nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_free_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mi_free_aligned(void* p, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_aligned", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_aligned(nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_nothrow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_nothrow(nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_aligned_nothrow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_aligned_nothrow(nuint size, nuint alignment);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_n", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_n(nuint count, nuint size);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_realloc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_realloc(void* p, nuint newsize);

        [DllImport(NATIVE_LIBRARY, EntryPoint = "mi_new_reallocn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* mi_new_reallocn(void* p, nuint newcount, nuint size);
    }
}