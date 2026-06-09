/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        // PRIMARY BRAND
        "primary": "#1a303a",
        "primary-container": "#243f4c",
        "primary-fixed": "#d6e5eb",
        "primary-fixed-dim": "#9eb6c1",
        "inverse-primary": "#a9c0cb",

        // BACKGROUND
        "background": "#f5f8fa",
        "surface": "#f5f8fa",
        "surface-dim": "#d7e2e7",
        "surface-bright": "#ffffff",

        // SURFACE
        "surface-container-lowest": "#ffffff",
        "surface-container-low": "#eef3f6",
        "surface-container": "#e4ebef",
        "surface-container-high": "#dbe5ea",
        "surface-container-highest": "#d1dde3",

        // TEXT
        "on-background": "#12232b",
        "on-surface": "#12232b",
        "on-surface-variant": "#586670",

        // SECONDARY
        "secondary": "#2d5d6f",
        "secondary-container": "#d5ebf3",
        "secondary-fixed": "#dceef5",
        "secondary-fixed-dim": "#b5d3df",
        "on-secondary": "#ffffff",
        "on-secondary-container": "#163743",

        // TERTIARY
        "tertiary": "#456b57",
        "tertiary-container": "#d9efe2",
        "tertiary-fixed": "#dcefe5",
        "tertiary-fixed-dim": "#b4d3c0",
        "on-tertiary": "#ffffff",

        // BORDERS
        "outline": "#8897a0",
        "outline-variant": "#c7d2d8",

        // STATES
        "error": "#ba1a1a",
        "error-container": "#ffdad6",
        "on-error": "#ffffff",
        "on-error-container": "#93000a",

        // INVERSE
        "inverse-surface": "#1a303a",
        "inverse-on-surface": "#eef5f8",

        // EXTRA
        "surface-tint": "#1a303a"
      },
      "borderRadius": {
        "DEFAULT": "0.125rem",
        "lg": "0.25rem",
        "xl": "0.5rem",
        "full": "0.75rem"
      },
      "spacing": {
        "stack-md": "16px",
        "gutter": "24px",
        "container-max": "1200px",
        "stack-sm": "8px",
        "stack-lg": "32px",
        "base": "8px",
        "margin-desktop": "48px",
        "margin-mobile": "16px"
      },
      "fontFamily": {
        "code": ["Public Sans"],
        "body-sm": ["Public Sans"],
        "body-md": ["Public Sans"],
        "headline-md": ["Public Sans"],
        "headline-lg": ["Public Sans"],
        "body-lg": ["Public Sans"],
        "label-md": ["Public Sans"],
        "headline-lg-mobile": ["Public Sans"],
        "label-lg": ["Public Sans"],
        "headline-xl": ["Public Sans"],
        "headline-xl-mobile": ["Public Sans"]
      },
      "fontSize": {
        "code": ["14px", { "lineHeight": "20px", "letterSpacing": "0.1em", "fontWeight": "700" }],
        "body-sm": ["14px", { "lineHeight": "20px", "fontWeight": "400" }],
        "body-md": ["16px", { "lineHeight": "24px", "fontWeight": "400" }],
        "headline-md": ["24px", { "lineHeight": "32px", "fontWeight": "600" }],
        "headline-lg": ["32px", { "lineHeight": "40px", "fontWeight": "600" }],
        "body-lg": ["18px", { "lineHeight": "28px", "fontWeight": "400" }],
        "label-md": ["12px", { "lineHeight": "16px", "fontWeight": "500" }],
        "headline-lg-mobile": ["24px", { "lineHeight": "32px", "fontWeight": "600" }],
        "label-lg": ["14px", { "lineHeight": "20px", "letterSpacing": "0.05em", "fontWeight": "600" }],
        "headline-xl": ["40px", { "lineHeight": "48px", "letterSpacing": "-0.02em", "fontWeight": "700" }],
        "headline-xl-mobile": ["30px", { "lineHeight": "36px", "letterSpacing": "-0.01em", "fontWeight": "700" }],

        "menu-lg": ["18px", { "lineHeight": "28px", "fontWeight": "400" }],
        "menu-md": ["14px", { "lineHeight": "16px", "fontWeight": "500" }],

        "table-head": ["13px", { "lineHeight": "18px", "fontWeight": "500" }],
        "table-body": ["13px", { "lineHeight": "18px", "fontWeight": "400" }],
        "table-badge": ["12px", { "lineHeight": "16px", "fontWeight": "600" }]
      }
    }
  },
  plugins: []
};