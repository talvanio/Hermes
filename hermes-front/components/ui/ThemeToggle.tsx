"use client"
import { Moon, Sun } from 'lucide-react'
import { Button } from '@/components/shadcn/ui/button'
import { useGlobalTheme } from '@/app/ThemeProvider'

export function ThemeToggle() {
  const { theme, toggleTheme } = useGlobalTheme()
  return (
    <Button
      variant="outline"
      size="icon"
      onClick={toggleTheme}
      className="fixed top-4 right-4"
    >
      {theme === 'light' ? (
        <Moon className="h-5 w-5" />
      ) : (
        <Sun className="h-5 w-5" />
      )}
      <span className="sr-only">Toggle theme</span>
    </Button>
  )
}