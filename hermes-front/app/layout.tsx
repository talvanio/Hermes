"use client"
import { ThemeToggle } from "@/components/ui/ThemeToggle";
import "./globals.css";
import { ThemeProvider } from "./ThemeProvider";
import { useAuth } from "@/hooks/use-auth";
import { Button } from "@/components/shadcn/ui/button";
import { useRouter, usePathname } from 'next/navigation'
import { LogOut } from 'lucide-react'

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  
  const pathname = usePathname()
  const {logout} = useAuth()
  const isLoginPage = pathname === "/login"

  return (
    <html lang="en" className="dark">
      <body>
        <ThemeProvider>
          {/* logout and theme buttons div*/}
          <div className="fixed top-4 right-4 z-[1000] flex items-center gap-2">
          
          {/* Only shows logout button if not currently in login page */}
          {
            !isLoginPage && 
            <Button variant="outline" size="icon" onClick={() => logout()}>
              <LogOut className="h-5 w-5" />
            </Button>
          }
          
        <ThemeToggle />

          </div>
          {children}
        </ThemeProvider>
      </body>
    </html>
  );
}
