import { ThemeToggle } from "@/components/ui/theme-toggle";
import "./globals.css";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" className="dark">
      <body>
        <div>Hermes app home</div>
        <ThemeToggle />
        {children}
      </body>
    </html>
  );
}
