using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HtmlForgeX.Tags;
using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX.Examples.Containers;

internal class MultiPagePerformanceBenchmark {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Multi-Page Performance Benchmark");

        // Create sample data for realistic pages
        var products = GenerateSampleProducts(100);
        var categories = new[] { "Electronics", "Clothing", "Books", "Home & Garden", "Sports" };

        // Sequential generation
        Console.WriteLine("\n🔄 Sequential Page Generation:");
        var sequentialStopwatch = Stopwatch.StartNew();
        CreateSequentialSite(products, categories);
        sequentialStopwatch.Stop();
        Console.WriteLine($"✅ Sequential generation completed in: {sequentialStopwatch.ElapsedMilliseconds}ms");

        // Parallel generation
        Console.WriteLine("\n⚡ Parallel Page Generation:");
        var parallelStopwatch = Stopwatch.StartNew();
        CreateParallelSiteAsync(products, categories).Wait();
        parallelStopwatch.Stop();
        Console.WriteLine($"✅ Parallel generation completed in: {parallelStopwatch.ElapsedMilliseconds}ms");

        // Calculate improvement
        var improvement = ((double)sequentialStopwatch.ElapsedMilliseconds - parallelStopwatch.ElapsedMilliseconds) 
                          / sequentialStopwatch.ElapsedMilliseconds * 100;
        Console.WriteLine($"\n📊 Performance improvement: {improvement:F1}% faster with parallel generation");
        Console.WriteLine($"🚀 Time saved: {sequentialStopwatch.ElapsedMilliseconds - parallelStopwatch.ElapsedMilliseconds}ms");
    }

    private static void CreateSequentialSite(dynamic[] products, string[] categories) {
        var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

        // Configure shared navigation
        multiPageDoc.WithSharedNavigation(nav => nav
            .WithLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png", "index.html")
            .WithSticky()
            .AddItem("Home", "index.html")
            .AddItem("Products", "products.html")
            .AddItem(item => item
                .WithText("Categories")
                .WithIcon(TablerIconType.Category)
                .AddDropdownItem("All Categories", "categories.html")
                .AddDropdownItem("Electronics", "category-electronics.html")
                .AddDropdownItem("Clothing", "category-clothing.html"))
            .AddItem("About", "about.html")
            .AddItem("Contact", "contact.html"))
            .WithSharedFooter("© 2024 HtmlForgeX Performance Demo. All rights reserved.");

        // Add home page
        multiPageDoc.AddPageWithLayout("home", "index.html", "Home - Performance Demo", page => {
            page.H1("Multi-Page Performance Demo");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Sequential Generation Test"));
                        card.Add(new TablerText("This site was generated using sequential page generation."));
                        card.ProgressBar(TablerProgressBarType.Small, 100, TablerColor.Success);
                    });
                });
            });
        });

        // Add products page with large table
        multiPageDoc.AddPageWithLayout("products", "products.html", "Products", page => {
            page.H1("Product Catalog");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title($"All Products ({products.Length} items)"));
                        card.Add(new TablerTable(products, TableType.DataTables));
                    });
                });
            });
        });

        // Add category pages
        foreach (var category in categories) {
            var categoryProducts = GenerateCategoryProducts(category, 20);
            multiPageDoc.AddPageWithLayout($"cat-{category.ToLower()}", 
                $"category-{category.ToLower().Replace(" ", "-")}.html", 
                $"{category} Products", 
                page => {
                    page.H1($"{category} Products");
                    page.Row(row => {
                        row.Column(TablerColumnNumber.Twelve, col => {
                            col.Card(card => {
                                card.Header(h => h.Title($"{category} ({categoryProducts.Length} items)"));
                                card.Add(new TablerTable(categoryProducts, TableType.DataTables));
                            });
                        });
                    });
                });
        }

        // Add categories overview page
        multiPageDoc.AddPageWithLayout("categories", "categories.html", "All Categories", page => {
            page.H1("Product Categories");
            page.Row(row => {
                foreach (var category in categories) {
                    row.Column(TablerColumnNumber.Four, col => {
                        col.Card(card => {
                            card.Header(h => h.Title(category));
                            card.Add(new TablerText($"Browse our {category} collection"));
                            card.Footer(f => f.Add(new TablerButton("View Products", $"category-{category.ToLower().Replace(" ", "-")}.html", TablerButtonVariant.Primary)));
                        });
                    });
                }
            });
        });

        // Add about page
        multiPageDoc.AddPageWithLayout("about", "about.html", "About Us", page => {
            page.H1("About Performance Demo");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Sequential Generation"));
                        card.Add(new TablerText("This site demonstrates sequential page generation where each page is created one after another."));
                        card.Steps()
                            .AddStep("Page 1 Generated", TablerStepState.Completed)
                            .AddStep("Page 2 Generated", TablerStepState.Completed)
                            .AddStep("Page 3 Generated", TablerStepState.Completed)
                            .AddStep("All Pages Complete", TablerStepState.Completed);
                    });
                });
            });
        });

        // Add contact page
        multiPageDoc.AddPageWithLayout("contact", "contact.html", "Contact", page => {
            page.H1("Contact Us");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Get in Touch"));
                        card.DataGrid(grid => {
                            grid.AddItem("Email", "performance@htmlforgex.com");
                            grid.AddItem("Phone", "+1 234 567 8900");
                            grid.AddItem("Address", "123 Performance St, Speed City");
                        });
                    });
                });
            });
        });

        // Save all pages sequentially
        multiPageDoc.SaveAll("MultiPagePerformanceBenchmark_Sequential", false);
        multiPageDoc.Dispose();
    }

    private static async Task CreateParallelSiteAsync(dynamic[] products, string[] categories) {
        var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

        // Configure shared navigation (same as sequential)
        multiPageDoc.WithSharedNavigation(nav => nav
            .WithLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png", "index.html")
            .WithSticky()
            .AddItem("Home", "index.html")
            .AddItem("Products", "products.html")
            .AddItem(item => item
                .WithText("Categories")
                .WithIcon(TablerIconType.Category)
                .AddDropdownItem("All Categories", "categories.html")
                .AddDropdownItem("Electronics", "category-electronics.html")
                .AddDropdownItem("Clothing", "category-clothing.html"))
            .AddItem("About", "about.html")
            .AddItem("Contact", "contact.html"))
            .WithSharedFooter("© 2024 HtmlForgeX Performance Demo. All rights reserved.");

        // Add all the same pages
        multiPageDoc.AddPageWithLayout("home", "index.html", "Home - Performance Demo", page => {
            page.H1("Multi-Page Performance Demo");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Parallel Generation Test"));
                        card.Add(new TablerText("This site was generated using parallel page generation."));
                        card.ProgressBar(TablerProgressBarType.Small, 100, TablerColor.Info);
                    });
                });
            });
        });

        // Add products page
        multiPageDoc.AddPageWithLayout("products", "products.html", "Products", page => {
            page.H1("Product Catalog");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title($"All Products ({products.Length} items)"));
                        card.Add(new TablerTable(products, TableType.DataTables));
                    });
                });
            });
        });

        // Add category pages
        foreach (var category in categories) {
            var categoryProducts = GenerateCategoryProducts(category, 20);
            multiPageDoc.AddPageWithLayout($"cat-{category.ToLower()}", 
                $"category-{category.ToLower().Replace(" ", "-")}.html", 
                $"{category} Products", 
                page => {
                    page.H1($"{category} Products");
                    page.Row(row => {
                        row.Column(TablerColumnNumber.Twelve, col => {
                            col.Card(card => {
                                card.Header(h => h.Title($"{category} ({categoryProducts.Length} items)"));
                                card.Add(new TablerTable(categoryProducts, TableType.DataTables));
                            });
                        });
                    });
                });
        }

        // Add categories overview
        multiPageDoc.AddPageWithLayout("categories", "categories.html", "All Categories", page => {
            page.H1("Product Categories");
            page.Row(row => {
                foreach (var category in categories) {
                    row.Column(TablerColumnNumber.Four, col => {
                        col.Card(card => {
                            card.Header(h => h.Title(category));
                            card.Add(new TablerText($"Browse our {category} collection"));
                            card.Footer(f => f.Add(new TablerButton("View Products", $"category-{category.ToLower().Replace(" ", "-")}.html", TablerButtonVariant.Primary)));
                        });
                    });
                }
            });
        });

        // Add about page
        multiPageDoc.AddPageWithLayout("about", "about.html", "About Us", page => {
            page.H1("About Performance Demo");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Parallel Generation"));
                        card.Add(new TablerText("This site demonstrates parallel page generation where pages are created simultaneously."));
                        card.Steps()
                            .AddStep("All Pages Start", TablerStepState.Completed)
                            .AddStep("Parallel Processing", TablerStepState.Completed)
                            .AddStep("Concurrent Writing", TablerStepState.Completed)
                            .AddStep("Completed Faster!", TablerStepState.Completed);
                    });
                });
            });
        });

        // Add contact page
        multiPageDoc.AddPageWithLayout("contact", "contact.html", "Contact", page => {
            page.H1("Contact Us");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Get in Touch"));
                        card.DataGrid(grid => {
                            grid.AddItem("Email", "performance@htmlforgex.com");
                            grid.AddItem("Phone", "+1 234 567 8900");
                            grid.AddItem("Address", "123 Performance St, Speed City");
                        });
                    });
                });
            });
        });

        // Save all pages in parallel
        await multiPageDoc.SaveAllAsync("MultiPagePerformanceBenchmark_Parallel", false);
        multiPageDoc.Dispose();
    }

    private static dynamic[] GenerateSampleProducts(int count) {
        var products = new dynamic[count];
        var random = new Random();
        
        for (int i = 0; i < count; i++) {
            products[i] = new {
                Id = i + 1,
                Name = $"Product {i + 1}",
                Category = new[] { "Electronics", "Clothing", "Books", "Home & Garden", "Sports" }[random.Next(5)],
                Price = $"${random.Next(10, 1000)}.{random.Next(100):D2}",
                Stock = random.Next(0, 100),
                Rating = $"{random.Next(30, 50) / 10.0:F1}",
                Description = $"This is a detailed description for Product {i + 1}"
            };
        }
        
        return products;
    }

    private static dynamic[] GenerateCategoryProducts(string category, int count) {
        var products = new dynamic[count];
        var random = new Random();
        
        for (int i = 0; i < count; i++) {
            products[i] = new {
                Id = $"{category[0]}{i + 1}",
                Name = $"{category} Product {i + 1}",
                Price = $"${random.Next(10, 1000)}.{random.Next(100):D2}",
                Stock = random.Next(0, 100),
                Rating = $"{random.Next(30, 50) / 10.0:F1}"
            };
        }
        
        return products;
    }
}